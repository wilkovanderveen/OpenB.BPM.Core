using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace OpenB.BPM.Core.Test
{
    [TestFixture]
    public partial class RepositoryTest
    {
        [Test]
        public void Repository_Create_ReturnsNewPerson()
        {
            IDataContext mockDataContext = Mock.Of<IDataContext>();

            RepositoryOptions personRepositoryOptions = new RepositoryOptions();
            personRepositoryOptions.KeyGenertor = new GuidKeyGenerator();

            ModelDefinition personModelDefinition = new ModelDefinition("Person");
            IList<ModelDefinition> modelDefinitions = new List<ModelDefinition>();
            modelDefinitions.Add(personModelDefinition);

            ModelDefinitionConfiguration modelDefinitionConfiguration = new ModelDefinitionConfiguration(modelDefinitions);
            ModelDefinitionConfiguration.instance = modelDefinitionConfiguration;

            Repository<Person> personRepository = new Repository<Person>(personRepositoryOptions, mockDataContext);

            Person newPerson = personRepository.Create();

            Assert.That(newPerson, Is.Not.Null);
            Assert.That(newPerson.Key, Is.Null);
        }

        [Test]
        public void Repository_Save_KeyPropertyIsSet()
        {
            IDataContext mockDataContext = Mock.Of<IDataContext>();

            RepositoryOptions personRepositoryOptions = new RepositoryOptions();
            personRepositoryOptions.KeyGenertor = new GuidKeyGenerator();

            ModelDefinition personModelDefinition = new ModelDefinition("Person");
            IList<ModelDefinition> modelDefinitions = new List<ModelDefinition>();
            modelDefinitions.Add(personModelDefinition);

            ModelDefinitionConfiguration modelDefinitionConfiguration = new ModelDefinitionConfiguration(modelDefinitions);
            ModelDefinitionConfiguration.instance = modelDefinitionConfiguration;


            Repository<Person> personRepository = new Repository<Person>(personRepositoryOptions, mockDataContext);

            Person newPerson = personRepository.Create();

            Assert.That(newPerson, Is.Not.Null);

            personRepository.Save(newPerson);

            Assert.That(newPerson.Key, Is.Not.Null);
        }

        [Test]
        public void Repository_SubModel_Is_BeingSet()
        {
            IDataContext mockDataContext = Mock.Of<IDataContext>();

            RepositoryOptions personRepositoryOptions = new RepositoryOptions();
            personRepositoryOptions.KeyGenertor = new GuidKeyGenerator();

            ModelDefinition personModelDefinition = new ModelDefinition("Person");
            ModelDefinition addressModelDefinition = new ModelDefinition("Address");

            personModelDefinition.AddProperty("Address", addressModelDefinition);

            IList<ModelDefinition> modelDefinitions = new List<ModelDefinition>();
            modelDefinitions.Add(personModelDefinition);
            modelDefinitions.Add(addressModelDefinition);

            ModelDefinitionConfiguration modelDefinitionConfiguration = new ModelDefinitionConfiguration(modelDefinitions);
            ModelDefinitionConfiguration.instance = modelDefinitionConfiguration;

            Repository<Person> personRepository = new Repository<Person>(personRepositoryOptions, mockDataContext);

            Person newPerson = personRepository.Create();

            newPerson.Address = new Address();

          
        }

        [Test]
        public void Repository_Where_IsBeing_Disected()
        {
            Mock<IDataContext> mockDataContext = new Mock<IDataContext>();

            IEnumerable<Person> persons = new List<Person>();

            mockDataContext.Setup(dc => dc.ProcessExpression(It.IsAny<SelectionExpressionData>())).Returns(persons);


            RepositoryOptions personRepositoryOptions = new RepositoryOptions();
            personRepositoryOptions.KeyGenertor = new GuidKeyGenerator();

            ModelDefinition personModelDefinition = new ModelDefinition("Person");
            ModelDefinition addressModelDefinition = new ModelDefinition("Address");

            personModelDefinition.AddProperty("Address", addressModelDefinition);

            IList<ModelDefinition> modelDefinitions = new List<ModelDefinition>();
            modelDefinitions.Add(personModelDefinition);
            modelDefinitions.Add(addressModelDefinition);

            ModelDefinitionConfiguration modelDefinitionConfiguration = new ModelDefinitionConfiguration(modelDefinitions);
            ModelDefinitionConfiguration.instance = modelDefinitionConfiguration;

            Repository<Person> personRepository = new Repository<Person>(personRepositoryOptions, mockDataContext.Object);

            Assert.That(personRepository.Where(p => p.Key == "Henk" && p.Address.Street == "Mainstreet"), Is.EqualTo(persons));
        }
    }
}
