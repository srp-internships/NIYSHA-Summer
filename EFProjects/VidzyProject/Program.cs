
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vidzy;

// Create a new video object
 static void AddVideo(Video video)
{
    using (var context = new DataContext())
    {
        context.Videos.Add(video);
        context.SaveChanges();
    }
}


AddVideo( new Video
{
    Name = "Terminator 1",
    ReleaseDate = new DateTime(1984, 10, 26),
    Classification = Classification.Silver
});



//Add tags
static void AddTags(params string[] tagNames)
{
    using (var context = new DataContext())
    {

        var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

        foreach (var name in tagNames)
        {
            if (!tags.Any(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                context.Tags.Add(new Tag { Name = name });
        }

        context.SaveChanges();
    }
}

AddTags("classics", "drama");



//Add TagVideo
static void AddTagsToVideo(int videoId, params string[] tagNames)
{
    using (var context = new DataContext())
    {
        var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

         foreach (var tagName in tagNames)
        {
            if (!tags.Any(t => t.Name.Equals(tagName, StringComparison.CurrentCultureIgnoreCase)))
                tags.Add(new Tag { Name = tagName });
        }

        var video = context.Videos.Single(v => v.Id == videoId);

        tags.ForEach(t => video.AddTag(t));

        context.SaveChanges();
    }
}

AddTagsToVideo(1, "classics", "drama", "comedy");



//remove comedy
static void RemoveTagsFromVideo(int videoId, params string[] tagNames)
{
    using (var context = new DataContext())
    {
        context.Tags.Where(t => tagNames.Contains(t.Name)).Load();

        var video = context.Videos.Single(v => v.Id == videoId);

        foreach (var tagName in tagNames)
        {
            video.RemoveTag(tagName);
        }

        context.SaveChanges();
    }
}

RemoveTagsFromVideo(1, "comedy");




// Remove the video with Id 1.
static void RemoveVideo(int videoId)
{
    using (var context = new DataContext())
    {
        var video = context.Videos.SingleOrDefault(v => v.Id == videoId);
        if (video == null) return;

        context.Videos.Remove(video);
        context.SaveChanges();
    }
}

RemoveVideo(1);



// RemoveGenre(2, true);
static void RemoveGenre(int genreId, bool enforceDeletingVideos)
{
    using (var context = new DataContext())
    {
        var genre = context.Genres.Include(g => g.Videos).SingleOrDefault(g => g.Id == genreId);
        if (genre == null) return;

        if (enforceDeletingVideos)
            context.Videos.RemoveRange(genre.Videos);

        context.Genres.Remove(genre);
        context.SaveChanges();
    }
}

RemoveGenre(2, enforceDeletingVideos: true);


 


 




    


