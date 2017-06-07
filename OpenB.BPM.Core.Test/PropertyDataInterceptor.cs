using Castle.DynamicProxy;
using System;

namespace OpenB.BPM.Core.Test
{
    public class PropertyDataInterceptor : IInterceptor
    {
        private ModelDefinition modelDefinition;

        public PropertyDataInterceptor(ModelDefinition modelDefinition)
        {
            this.modelDefinition = modelDefinition;
        }

        public void Intercept(IInvocation invocation)
        {
            string methodName = invocation.Method.Name;
            string propertyName = String.Empty;

            if (methodName.StartsWith("get_"))
            {
                propertyName = methodName.Substring(4, methodName.Length - 4);
            }

            if (methodName.StartsWith("set_"))
            {
                propertyName = methodName.Substring(4, methodName.Length - 4);
            }

            PropertyDefinition propertyDefinition = modelDefinition.GetPropertyDefinition(propertyName);

            var propertyDataHandler = PropertyDataHandlerFactory.GetHandler(propertyDefinition);

            try
            {
                

                propertyDataHandler.Handle(invocation.InvocationTarget);
                invocation.Proceed();
            }
            finally
            {

            }

        }
    }
}
