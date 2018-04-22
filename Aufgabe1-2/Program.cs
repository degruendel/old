using System;

namespace Aufgabe1_2
{
    class Program
    {
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        static int lenght = subjects.Length;
        static string wort1;
        static string wort2;
        static string wort3;
        static void Main(string[] args)
        {
            // fertiges Gedicht
            string[] verse = new string[lenght];

            // Schleife speichert einen Vers pro Durchlauf
            for (int i = 0; i < lenght; i++)
            {
                GetVerse();
                verse[i] = wort1 + " " + wort2 + " " + wort3;
            }

            // Schleife gibt Vers für Vers aus
            for (int j = 0; j < lenght; j++)
            {
                Console.WriteLine(verse[j]);
            }
        }

        public static void GetVerse()
        {
            // Zufallszahlen werden generiert
            Random rnd = new Random();
            int numbersubjects = rnd.Next(0, lenght);
            int numberverbs = rnd.Next(0, lenght);
            int numberobjects = rnd.Next(0, lenght);

            // Zahlen werden überprüft, ob sie schon verwendet wurden. Falls ja, werden neue Zahlen generiert. Falls nein, weiter.
            while (subjects[numbersubjects] == "used")
            {
                numbersubjects = rnd.Next(0, lenght);
            }
            while (verbs[numberverbs] == "used")
            {
                numberverbs = rnd.Next(0, lenght);
            }
            while (objects[numberobjects] == "used")
            {
                numberobjects = rnd.Next(0, lenght);
            }

            // Wort wird dem Vers hinzugefügt.
            wort1 = subjects[numbersubjects];
            wort2 = verbs[numberverbs];
            wort3 = objects[numberobjects];

            // Wort wird als "used" markiert
            subjects[numbersubjects] = "used";
            verbs[numberverbs] = "used";
            objects[numberobjects] = "used";
        }
    }
}

