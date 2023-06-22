﻿using System;
using TestNinja.Mocking;

namespace TestNinjaNet.Mocking
{
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnpocessedVideos()
        {

            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                return videos;
            }

        }
    }
}
