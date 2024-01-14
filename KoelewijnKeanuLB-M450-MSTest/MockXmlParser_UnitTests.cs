﻿using KoelewijnKeanuLB_M450;
using System.Xml;
namespace KoelewijnKeanuLB_M450_MSTest
{
    [TestClass]
    internal class MockXmlParser_UnitTests
    {
        private const string FilePath = "path\\to\\your\\Vocabulary.xml"; // Update with your actual file path

        [TestMethod]
        public void LoadXmlDocument_ValidFilePath_ShouldLoadXmlDocument()
        {
            // Arrange
            MockXmlParser mockXmlParser = new MockXmlParser(FilePath);

            // Act
            XmlDocument xmlDocument = mockXmlParser.LoadXmlDocument();

            // Assert
            Assert.IsNotNull(xmlDocument);
        }

        [TestMethod]
        public void GetVocabularyAndTranslations_ValidLanguage_ShouldReturnList()
        {
            // Arrange
            MockXmlParser mockXmlParser = new MockXmlParser(FilePath);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><language name='English'><word translation='Translation1'>Word1</word></language></root>");

            // Act
            List<string> result = mockXmlParser.GetVocabularyAndTranslations("English", xmlDocument);

            // Assert
            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<string> { "Word1", "Translation1" }, result);
        }

        [TestMethod]
        public void GetVocabularyAndTranslations_InvalidLanguage_ShouldReturnEmptyList()
        {
            // Arrange
            MockXmlParser mockXmlParser = new MockXmlParser(FilePath);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root></root>");

            // Act
            List<string> result = mockXmlParser.GetVocabularyAndTranslations("InvalidLanguage", xmlDocument);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void getRandomVocabularyAndTranslation_ValidInput_ShouldReturnListWithSizeTen()
        {
            // Arrange
            MockXmlParser mockXmlParser = new MockXmlParser(FilePath);
            List<string> vocabularyAndTranslation = new List<string> { "Word1", "Translation1", "Word2", "Translation2", "Word3", "Translation3" };

            // Act
            List<string> result = mockXmlParser.getRandomVocabularyAndTranslation(vocabularyAndTranslation);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count);
        }

        [TestMethod]
        public void getRandomVocabularyAndTranslation_EmptyInput_ShouldReturnEmptyList()
        {
            // Arrange
            MockXmlParser mockXmlParser = new MockXmlParser(FilePath);
            List<string> vocabularyAndTranslation = new List<string>();

            // Act
            List<string> result = mockXmlParser.getRandomVocabularyAndTranslation(vocabularyAndTranslation);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
