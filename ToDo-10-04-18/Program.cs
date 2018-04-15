using System;

namespace ToDo_10_04_18
{
    public class Person
    {
        public string Name;
        public int Age;

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 43;

            Person newPerson = new Person();
            newPerson.Name = "Dennis";
            newPerson.Age = 20;

            Console.WriteLine(newPerson);
        }
    }
}
