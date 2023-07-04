
using System.Linq;
using CodeFirst;

var context = new DataContext();

////LINQ sintax
//  var query =
//    from c in context.Courses
//    where c.Name.Contains("c#")
//    orderby c.Name
//    select c;
//foreach (var course in query)
//    Console.WriteLine(course.Name);

////Exrention methods
//var courses = context.Courses
//    .Where(c => c.Name.Contains("c#"))
//    .OrderBy(c => c.Name);

//foreach (var course in courses)
//    Console.WriteLine(course.Name);

//var querysecond =
//    from c in context.Courses
//    where c.Author.Id == 1
//    orderby c.Level descending, c.Name
//    select new { Name = c.Name, Author = c.Author.Name };


//var queruthird =
//    from c in context.Courses
//    group c by c.Level
//    into g
//    select g;

//foreach (var group in queruthird)
//{
//    Console.WriteLine("{0},{1}",group.Key,group.Count());
//}


//var queryfourth =
//    from c in context.Courses
//    join a in context.Authors on c.AuthorId equals a.Id
//    select new { CourseName = c.Name, AuthorName = a.Name };


//var countquery =
//    from a in context.Authors
//    join c in context.Courses on a.Id equals c.AuthorId into g
//    select new { AuthorName = a.Id, Courses = g.Count() };

//foreach (var x in countquery)
//    Console.WriteLine("{0},{1}", x.AuthorName, x.Courses);

//var queryjoin =
//    from a in context.Authors
//    from c in context.Courses
//    select new { AuthorName = a.Name, CourseName = c.Name };

//foreach (var x in queryjoin)
//{
//    Console.WriteLine("{0},{1}", x.AuthorName, x.CourseName);

//}

//var tags = context.Courses
//    .Where(c => c.Level == 1)
//    .OrderByDescending(c => c.Name)
//    .ThenByDescending(c => c.Level)
//    .SelectMany(c => c.Tags)
//    .Distinct();

//foreach(var t in tags)
//{
//     Console.WriteLine(t.Name);
//}

//var groups = context.Courses.GroupBy(c => c.Level);
//foreach(var group in groups)
//{
//    Console.WriteLine("Key:" + group.Key);
//    foreach(var course in group)
//    {
//        Console.WriteLine("\t"+course.Name);
//    }
//}

//context.Courses.OrderBy(c => c.Level).FirstOrDefault(c => c.FullPrice > 100);

//var allAbove100Dollers=context.Courses.All(c => c.FullPrice > 10);
//var count=context.Courses.Where(c=>c.Level==1).Count();
//context.Courses.Max(c => c.FullPrice);
//context.Courses.Min(c => c.FullPrice);
//context.Courses.Average(c => c.FullPrice);


IEnumerable<Course> courses = context.Courses;
var filtired = courses.Where(c => c.Level == 1);
foreach(var course in filtired)
{
    Console.WriteLine(course.Name);
}