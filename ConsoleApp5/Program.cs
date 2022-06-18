using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var shmaroltd = new Company("ShmaroLtd");
            var dblvgntoo = new Company("DoubleToo");
            var tualet = new Company("Tualet Jondeu");
            var butterfly = new Company("Night Butterfly");
            var government = new Company("Akimat");
            var kolyan = new User
            {
                FirstName = "Kolyan",
                LastName = "Petrosyan"
            };
            var tatiana = new User
            {
                FirstName = "Tatyana",
                LastName = "Ultuarov"
            };
            var nasralbek = new User
            {
                FirstName = "Nasralbek",
                LastName = "Ulugbek"
            };
            var batyrkhan = new User
            {
                FirstName = "Batyrkhan",
                LastName = "Vipkazakh"
            };
            var cumshot = new User
            {
                FirstName = "Cumshat",
                LastName = "Betalganova"
            };

            Person[] user = new Person[]
            {
                new Person(kolyan, 5432432, "Yessirkepov Beglan", shmaroltd),
                new Person(tatiana, 5421431, "Yessirkepov Beglan", dblvgntoo),
                new Person(nasralbek, 5421459, "Yessirkepov Beglan", butterfly),
                new Person(batyrkhan, 5777777, "Yessirkepov Beglan", government),
                new Person(cumshot, 5543547, "Yessirkepov Beglan", tualet)

            };

            XmlSerializer formatter = new XmlSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("user.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);
            }

            using (FileStream fs = new FileStream("user.xml", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is Person[] newpeople)
                {
                    foreach (Person person in newpeople)
                    {
                        Console.WriteLine($"First Name: {person.User.FirstName}");
                        Console.WriteLine($"Last Name: {person.User.LastName}");
                        Console.WriteLine($"Bin: {person.Bin}");
                        Console.WriteLine($"Author create: {person.Authorcreate}");
                        Console.WriteLine($"Company: {person.Company.Name}");
                    }
                }
            }
        }
        public class Person 
        {
            public int Bin { get; set; } 
            public string Authorcreate { get; set; } 
            public Company Company { get; set; } = new Company();
            public User User { get; set; } = new User();


            public Person() { }
            public Person(User user, int bin, string authorcreate, Company company)
            {
                User = user;
                Bin = bin;
                Authorcreate = authorcreate;
                Company = company;
            }
        }
        public class Company 
        {
            public string Name { get; set; } = "Undefined";
            public Company() { }

            public Company(string name) => Name = name;
        }
        public class User 
        {
            public string FirstName { get; set; } = "Undefined";
            public string LastName { get; set; } = "Undefined";
            public User() { }
            public User(string fname, string lname)
            {
                FirstName = fname;
                LastName = lname;
            }

        }
    }
}
