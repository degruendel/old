using System;
using System.Collections.Generic;

namespace Aufgabe5
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        public List<Participants<P>> ParticipantsList = new List<ParticipantsList<P>>();

        public List<Course<C>> CourseList = new List<CourseList<C>>();

        public class Person
        {
            public string name;
            public int age;
        }
        public class Teilnehmer : Person
        {
            public int matrikelnr;
            public CourseList<C> Course; 
        }
        public class Dozent : Person
        {
            public string room;
            public DateTime availabletime;
            public CourseList<C> Course; 

            public void AddCourse(CourseList<C> course)
        {
            CourseList.Add(course);
        }
            public void AddParticipants(ParticipantsList<P> Teilnehmer)
        {
            ParticipantsList.Add(Teilnehmer);
        } 
        }
        public class Course
        {
            public string title;
            public DateTime date;
            public string room;

            public string outputInformationText()
            {
                return ;
            }
        }
    }
}