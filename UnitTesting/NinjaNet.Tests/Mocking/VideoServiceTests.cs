using System;
using Moq;
using TestNinja.Mocking;
using TestNinjaNet.Mocking;

namespace NinjaNet.Tests.Mocking
{
    public class VideoServiceTests 
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IVideoRepository>();
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object,_repository.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
           
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }


        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideopPocessed_ReturnEmptyString()
        {
            _repository.Setup(r => r.GetUnpocessedVideos()).Returns(new List<Video>());
            var result=_videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo(""));

        }
        [Test]
        public void GetUnprocessedVideosAsCsv_FewVideopPocessed_ReturnEmptyString()
        {
            _repository.Setup(r => r.GetUnpocessedVideos()).Returns(new List<Video>()
            { new Video   { Id=1},
              new Video   { Id=2},
              new Video   { Id=3},
            });
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo("1,2,3"));

        }


    }
}

