using System;
using static System.Console;

namespace Debugging
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;

        public Person Mom;
        public Person Dad;
    }


    public class Familytree
    {
        /* public static Person Find(Person person)
        {
            Person ret = null;
            if (person.LastName == "Roche")
                return person;

            ret = Find(person.Mom);
            if (ret != null)
                return ret;
            ret = Find(person.Dad);
            return ret;
        } */

        public static Person Find(Person person)
        {
            Person ret = null;
            int age = DateTime.Now.Year - person.DateOfBirth.Year;
            if(135 < age && age < 137)
                return person;
                
            if(person.Mom != null)
            ret = Find(person.Mom);
            if (ret != null)
                return ret;
            if(person.Mom != null)
            ret = Find(person.Dad);
            return ret;
        }



        public static Person BuildTree()
        {
            return  
                new Person { FirstName = "Willi", LastName = "Cambridge", DateOfBirth=new DateTime(1982, 07, 21), //36
                    Mom = new Person { FirstName = "Diana", LastName = "Spencer", DateOfBirth = new DateTime(1961, 07, 01), //57
                        Mom = new Person {FirstName = "Franzi", LastName="Roche", DateOfBirth = new DateTime(1936, 01, 20), //82
                            Mom = new Person {FirstName = "Ruth", LastName="Gill", DateOfBirth = new DateTime(1908, 06, 07)}, //110
                            Dad = new Person {FirstName = "Moritz", LastName="Roche", DateOfBirth = new DateTime(1885, 07, 08)} //133
                        },
                        Dad = new Person {FirstName = "Eddie", LastName="Spencer", DateOfBirth = new DateTime(1924, 01, 24), //94
                            Mom = new Person {FirstName = "Cynthia", LastName="Hamilton", DateOfBirth = new DateTime(1897, 08, 16)}, //121
                            Dad = new Person {FirstName = "Albert", LastName="Spencer", DateOfBirth = new DateTime(1892, 05, 23)} //126
                        },
                    },
                    Dad = new Person {FirstName = "Charlie", LastName = "Wales", DateOfBirth = new DateTime(1948, 11, 14), //70
                        Mom = new Person {FirstName = "Else", LastName="Windsor", DateOfBirth = new DateTime(1926, 04, 21), //92
                            Mom = new Person {FirstName = "Lisbeth", LastName="Bowes-Lyon", DateOfBirth = new DateTime(1900, 08, 04)}, //118
                            Dad = new Person {FirstName = "Schorsch-Albert", LastName="York", DateOfBirth = new DateTime(1895, 12, 14)} //123
                        },
                        Dad = new Person {FirstName = "Philip", LastName="Battenberg", DateOfBirth = new DateTime(1921, 06, 10), //97
                            Mom = new Person {FirstName = "Alice", LastName="Battenberg", DateOfBirth = new DateTime(1885, 02, 25)}, //133
                            Dad = new Person {FirstName = "Andi", LastName="ElGreco", DateOfBirth = new DateTime(1882, 02, 01)}, //136
                        },
                    },
                };
        }
    }
}