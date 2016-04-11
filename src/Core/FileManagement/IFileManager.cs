namespace Workshop.FileManagement
{
    public interface IFileManager
    {
        string ReadContentsOf(string fileName);
        void WriteToFile(string fileName, string textToWrite);
        string ConvertToFileSystemPath(string relativeWebPath);
        bool FileExists(string fileNameWithPath);
    }
}