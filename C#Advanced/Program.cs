using System.Threading.Tasks;

using CSharp.Advanced;

PersonTask task = new PersonTask();
Person person=new Person();


List<Person> people = new List<Person>
        {
            new Person { Id = 1, Name = "Alice", Position = "Junior Software Developer",Experience=2 },
            new Person { Id = 2, Name = "Bob", Position = "Senior Software Developer", Experience=10 },
            new Person { Id = 3, Name = "Charlie", Position = "Junior Software Developer", Experience=2 },
            new Person { Id = 4, Name = "Dave", Position = "Senior Software Developer", Experience=8 }
        };

Task task1 = new Task(() => person.GetBusyPerson(people));
task1.Start();

Task task2 = new Task(() => person.GetFreePerson(people));
task2.Start();

Task task3 = new Task(() => person.GetExperience(people));
task3.Start();
Task task4 = new Task(() => person.GetPersonByID(people, 2));
task4.Start();
Task task5 = new Task(() => person.GetAllPerson(people));
task5.Start();
Thread.Sleep(1000);




Task[] tasks = new Task[4];

for (int i = 0; i <= 3; i++)
{
    var j = i;
    // Console.WriteLine(people[i].Name);
    tasks[i] = Task.Run(() =>
  {

      try
      {
          Console.WriteLine($" {people[j].Name} is started task.");
          Console.WriteLine($"{people[j].Name} is busy.");

      }
      catch (Exception ex)
      {
          Console.WriteLine(j);
          Console.WriteLine(ex);
      }

  });
}



Console.ReadKey();
















