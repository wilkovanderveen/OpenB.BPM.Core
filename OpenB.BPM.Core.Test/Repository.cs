using Castle.DynamicProxy;
using OpenB.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OpenB.BPM.Core.Test
{
    public partial class RepositoryTest
    {
        public class Repository<T> : IRepository<T> where T : class, IModel
        {
            private ModelDefinition modelDefinition;
            private RepositoryOptions repositoryOptions;
            private IDataContext dataContext;

            public Repository(RepositoryOptions repositoryOptions, IDataContext dataContext)
            {
                this.repositoryOptions = repositoryOptions ?? throw new ArgumentNullException(nameof(repositoryOptions));
                this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));

                modelDefinition = ModelDefinitionConfiguration.GetInstance().GetDefinitionByType<T>();
            }

            public void Save(T model)
            {
                if (string.IsNullOrEmpty(model.Key))
                {
                    string key = repositoryOptions.KeyGenertor.GenerateKey();
                    typeof(T).GetProperty("Key").SetValue(model, key);
                }
            }

            public void Delete(T model)
            {

            }


            public T Create()
            {
                ProxyGenerator proxyGenerator = new ProxyGenerator();

                T model = Activator.CreateInstance<T>();
                return proxyGenerator.CreateClassProxyWithTarget<T>(model, new PropertyDataInterceptor(modelDefinition));

            }


            internal IEnumerable<T> Where(Expression<Func<T, bool>> whereExpression)
            {
                SelectionExpressionData selectorExpressionData = new SelectionExpressionData(DisectExpression(whereExpression.Body));

                IEnumerable result = dataContext.ProcessExpression(selectorExpressionData);     

                foreach (object item in result)
                {
                    yield return item as T;
                }

            }

            public ExpressionData DisectExpression(Expression expression)
            {
                switch (expression.NodeType)
                {
                    case ExpressionType.Equal:
                        return HandleEqualityExpression(expression as BinaryExpression);

                    case ExpressionType.MemberAccess:
                        return HandleModelPropertyAccessExpression(expression as MemberExpression);

                    case ExpressionType.Constant:
                        return HandleConstantExpression(expression as ConstantExpression);

                    case ExpressionType.AndAlso:
                        return HandleConditionalAndExpression(expression as BinaryExpression);


                }

                throw new NotSupportedException($"Expressiontype {expression.NodeType} is not supported.");
            }

            private ExpressionData HandleConditionalAndExpression(BinaryExpression binaryExpression)
            {
                ExpressionData left = DisectExpression(binaryExpression.Left);
                ExpressionData right = DisectExpression(binaryExpression.Right);
                return new ConditionalAndExpressionData(left, right);
            }

         

            private ExpressionData HandleConstantExpression(ConstantExpression constantExpression)
            {
                return new ConstantExpressionData(constantExpression.Value);
            }

            private ExpressionData HandleModelPropertyAccessExpression(MemberExpression memberExpression)
            {
                return new ModelPropertyAccessExpressionData(memberExpression.Member.ReflectedType, memberExpression.Member.Name);
            }

            private EqualityExpressionData HandleEqualityExpression(BinaryExpression binaryExpression)
            {
                ExpressionData leftExpression = DisectExpression(binaryExpression.Left);
                ExpressionData rightExpression = DisectExpression(binaryExpression.Right);

                return new EqualityExpressionData(leftExpression, rightExpression);
            }

            
        }
    }

    internal class ConditionalAndExpressionData : ExpressionData
    {
        private ExpressionData left;
        private ExpressionData right;

        public ConditionalAndExpressionData(ExpressionData left, ExpressionData right)
        {
            this.left = left;
            this.right = right;
        }
    }   

    public class SelectionExpressionData : ExpressionData
    {
        private ExpressionData expressionData;

        public SelectionExpressionData(ExpressionData expressionData)
        {
            this.expressionData = expressionData;
        }
    }

    public class EqualityExpressionData : ExpressionData
    {
        private ExpressionData leftExpression;
        private ExpressionData rightExpression;

        public EqualityExpressionData(ExpressionData leftExpression, ExpressionData rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }
    }

    public class ModelPropertyAccessExpressionData : ExpressionData
    {
        private string name;
        private Type modelType;

        public ModelPropertyAccessExpressionData(Type modelType, string propertyName)
        {
            this.name = propertyName;
            this.modelType = modelType;
        }
    }

    public class ConstantExpressionData : ExpressionData
    {
        private object value;

        public ConstantExpressionData(object value)
        {
            this.value = value;
        }
    }

    public class ExpressionData
    {

    }

    

}
