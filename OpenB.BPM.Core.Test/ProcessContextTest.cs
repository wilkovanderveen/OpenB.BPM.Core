using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using static OpenB.BPM.Core.Test.RepositoryTest;

namespace OpenB.BPM.Core.Test
{
    [TestFixture]
    public class ProcessContextTest
    {
        [Test]
        public void DoSomething()
        {
            IDataContext mockDataContext = Mock.Of<IDataContext>();

            IList<ModelDefinition> mockDefinitions = new List<ModelDefinition>();
            ModelDefinition personModelDefinition = new ModelDefinition("Person");
            IList<PropertyDefinition> mockPropertyDefinitions = new List<PropertyDefinition>();

            ModelDefinition addressModelDefinition = new ModelDefinition("Äddress");
            PropertyDefinition propertyDefinition = new PropertyDefinition(addressModelDefinition, "Address");
            mockPropertyDefinitions.Add(propertyDefinition);

            personModelDefinition.propertyDefinitions = mockPropertyDefinitions;


            mockDefinitions.Add(personModelDefinition);

            ModelDefinitionConfiguration.instance = new ModelDefinitionConfiguration(mockDefinitions);
            ModelCollection modelCollection = new ModelCollection();

            RepositoryOptions repositoryOptions = new RepositoryOptions();

            Repository<Person> personRepository = new Repository<Person>(repositoryOptions, mockDataContext);

            var person = personRepository.Create();

            person.Address = new Address();
        }
    }
}