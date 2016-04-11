using System.IO;
using Workshop.FileManagement;
using NUnit.Framework;

namespace Tests.FileManagementTests
{
    [TestFixture]
    public class FileManagerTests
    {
        private IFileManager _fileManager;
        private const string RelativeWebPath = "Relative/Web/Url/Path";
        private const string FileToWriteTo = "FileManagementTests/WrittenFile.txt";
        private const string FileToRead = "FileManagementTests/FileToRead.txt";

        [SetUp]
        public void SetUp()
        {
            _fileManager = new FileManager();
        }

        [TearDown]
        public void TearDown()
        {
            if(_fileManager.FileExists(FileToWriteTo))
            {
                File.Delete(FileToWriteTo);
            }
        }

        [Test]
        public void Should_ReadContentsOfTheFile_When_GivenAValidFileName()
        {
            var contents = _fileManager.ReadContentsOf(FileToRead);

            Assert.That(contents, Contains.Substring("brown"));
        }

        [Test]
        public void Should_WriteTextToFile_When_WriteToFileIsCalled()
        {
            _fileManager.WriteToFile(FileToWriteTo, "Jumped over the lazy dog.");
            var contents = _fileManager.ReadContentsOf(FileToWriteTo);
            Assert.That(contents, Contains.Substring("lazy"));
        }

        [Test]
        public void Should_ConvertToFileSystemPath_When_GivenARelativeWebPath()
        {
            var result = _fileManager.ConvertToFileSystemPath(RelativeWebPath);

            Assert.That(result, Is.EqualTo("Relative_Web_Url_Path"));
        }

        [Test]
        public void Should_ReturnTrue_When_CallingFileExistsWithAnExistingFileName()
        {
            _fileManager.WriteToFile(FileToWriteTo, "File Exists");

            Assert.That(_fileManager.FileExists(FileToWriteTo), Is.True);
        }

        [Test]
        public void Should_ReturnFalse_When_CallingFileExistsWithANonExistingFileName()
        {
            const string fileDoesNotExist = "File Does Not Exist";

            Assert.That(_fileManager.FileExists(fileDoesNotExist), Is.False);
        }
    }
}