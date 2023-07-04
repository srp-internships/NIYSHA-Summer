using System;
using Vidzy;

namespace VidzyProject
{
    public class LINQ
    {
        //var context = new DataContext();


        ////Action movies query
        //var actionMovie = context.Videos
        //    .Where(v => v.Genre.Name == "Action")
        //    .OrderBy(v => v.Name);
        //foreach (var v in actionMovie)
        //{
        //    Console.WriteLine(v.Name);
        //}

        //var goldMovie = context.Videos
        //    .Where(v => v.Genre.Name == "Drama" && v.Classification==Classification.Gold)
        //    .OrderByDescending(v => v.ReleaseDate);
        //foreach(var m in goldMovie)
        //{
        //    Console.WriteLine(m.Name);
        //}

        //var proMovie = context.Videos
        //    .Select(v => new { MovieName = v.Name, Genre = v.Genre.Name });
        //foreach (var m in proMovie)
        //{
        //    Console.WriteLine(m.MovieName);
        //}

        //var classification = context.Videos
        //    .GroupBy(v => v.Classification)
        //    .Select(m => new
        //    {
        //        Classification = m.Key.ToString(),
        //        Videos = m.OrderBy(n => n.Name)
        //    });

        //foreach(var v in classification)
        //{
        //    Console.WriteLine("Classification"+ v.Classification);
        //    foreach(var d in v.Videos)
        //    {
        //        Console.WriteLine("\t"+d.Name);
        //    }
        //}


        //var countclassification = context.Videos
        //    .GroupBy(v => v.Classification)
        //    .Select(m => new
        //    {
        //        Name = m.Key.ToString(),
        //        VideosCount = m.Count()
        //    })
        //    .OrderBy(c => c.Name);

        //foreach(var m in countclassification)
        //{
        //    Console.WriteLine("{0} ({1})",m.Name, m.VideosCount);
        //}


        //var genre = context.Genres
        //    .GroupJoin(context.Videos, g => g.Id, v => v.GenreId, (genre, videos) => new
        //    {
        //        Name = genre.Name,
        //        videosCount = videos.Count()
        //    })
        //    .OrderByDescending(g => g.videosCount);
        //foreach(var i in genre)
        //{
        //    Console.WriteLine("{0} ({1})", i.Name,i.videosCount);
        //}




        ////Lazy loading

        //var videos = context.Videos.ToList();
        //foreach( var v in videos)
        //{
        //    Console.WriteLine("{0} ({1}", v.Name,v.Genre.Name);
        //}




        ////Eager loading

        //var videosWithGenres = context.Videos.Include(v => v.Genre).ToList();

        //foreach (var v in videosWithGenres)
        //{
        //    Console.WriteLine("{0} ({1}", v.Name, v.Genre.Name);

        //}


        ////Explict loading
        //context.Genres.Load();
        //foreach (var v in videos)
        //{
        //    Console.WriteLine("{0} ({1}", v.Name, v.Genre.Name);

        //}

    }
}

