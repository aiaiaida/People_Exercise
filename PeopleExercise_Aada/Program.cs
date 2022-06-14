using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleExercise_Aada
{
    class Program
    {
        static void Main(string[] args)
        {
            Person A = new Person("Aaa", "A", "AAA@gmail.com", new DateTime(1995,8,12));
            Person B = new Person("Bbb", "B", "BBB@gmail.com", new DateTime(1975,4,30));
            Person C = new Person("Ccc", "C", "CCC@gmail.com", new DateTime(2001,5,6));
            Person D = new Person("Ddd", "D", "DDD@gmail.com", new DateTime(1989,3,18));
            Person E = new Person("Eee", "E", "EEE@gmail.com", new DateTime(1960,9,20));

            List<Person> lista = new List<Person>();
            lista.Add(A);
            lista.Add(B);
            lista.Add(C);
            lista.Add(D);
            lista.Add(E);

            //int averageAge = (Person.ReturnAge(A) + Person.ReturnAge(B) + Person.ReturnAge(C) + Person.ReturnAge(D) + Person.ReturnAge(E)) / 5;

            var res = from person in lista
                      where Person.ReturnAge(person) > lista.Average(person => Person.ReturnAge(person))
                      select new { name = person.FirstName + " " + person.LastName };
            res.ToList().ForEach(collections => Console.WriteLine(collections.name));
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string FirstName, string LastName, string Email, DateTime BirthDate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.BirthDate = BirthDate;
        }

        public Person(string FirstName, string LastName, string email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
        }

        public Person(string FirstName, string LastName, DateTime BirthDate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
        }

        public static int ReturnAge(Person person)
        {
            int age = 2022 - person.BirthDate.Year;
            return age;
        }
    }
}
