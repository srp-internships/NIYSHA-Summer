using System;
namespace CSharp.Advanced
{
    public  class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int TaskId { get; set; }
        public int Experience { get; set; }
       

        //The person who is assigned the task
       public  void GetBusyPerson(List<Person> people)
        {
            PersonTask persontask;

            var personhastask = from person in people
                                where person.Position == "Senior Software Developer"
                                select person;

            foreach (Person p in personhastask)
            {
               persontask = new PersonTask { Id = 1, TaskName = "Hard Task" };
                 p.TaskId = 1;
                Console.WriteLine($"{p.Name} has {persontask.TaskName}");
            }
        }


        //The person who is not assigned the task
        public void GetFreePerson(List<Person> people)
        {
            var personhasnottask = from person in people
                                   where person.TaskId == 0
                                   select person;

            foreach (Person person in personhasnottask)
            {
                Console.WriteLine($"{person.Name} has not Task");
            }
        }



        //The person who has more than 5 year experiences
        public void GetExperience(List<Person> people)
        {
            var listofpeople = from p in people
                     where p.Experience < 5
                     select p;

            foreach (Person person in listofpeople)
            {
                Console.WriteLine($"{person.Name} has experience more than 5 year");
            }
        }



        //Get the personbyid
        public  void GetPersonByID(List<Person> people, int id)
        {
            var listofpeople = from p in people
                         where (p.Id == id)
                         select p;

            foreach (Person person in listofpeople)
            {
               Console.WriteLine($"In this Id: {person.Name}");
            }

        }


        //Get all person with his experiences
        public void GetAllPerson(List<Person> people)
        {
            var listofpeople = from p in people
                            group p by p.Experience into NewGroup
                            select NewGroup;

            foreach (var peoplelist in listofpeople)
            {
                   foreach (Person p in peoplelist)
                {
                    Console.WriteLine($"{p.Name}, {p.Position}");
                }
               
            }
        }


    }
}

