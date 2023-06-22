namespace TestNinjaNet.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }
}