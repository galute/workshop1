namespace Workshop.FileManagement
{
    public class FileManager : IFileManager
    {
        public string ReadContentsOf(string fileName)
        {
            return System.IO.File.ReadAllText(fileName);
        }

        public void WriteToFile(string fileName, string textToWrite)
        {
            System.IO.File.WriteAllText(fileName, textToWrite);
        }

        public string ConvertToFileSystemPath(string relativeWebPath)
        {
            return relativeWebPath.Replace('/', '_').Trim('_').Replace(":", string.Empty);
        }

        public bool FileExists(string fileNameWithPath)
        {
            return System.IO.File.Exists(fileNameWithPath);
        }
    }
}
