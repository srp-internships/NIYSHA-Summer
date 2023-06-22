using TestNinja.Mocking;

namespace TestNinjaNet.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnpocessedVideos();
    }
}