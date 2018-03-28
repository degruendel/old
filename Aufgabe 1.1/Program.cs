using System;

namespace Aufgabe01
{
    class Program
    {

        static void Main(string[] args)
        {
            var Num = args[1];
            double d = Convert.ToDouble(Num);
            double A;
            double V;
            switch (args[0])
            {
                case "c":
                    A = getCubeSurface(d);
                    V = getCubeVolume(d);
                    break;

                case "k":
                    A = getSphereSurface(d);
                    V = getSphereVolume(d);
                    Console.WriteLine("Kugel:  A=" + A + "  |  V=" + V);
                    break;

                case "o":
                    A = getOktaederSurface(d);
                    V = getOktaederVolume(d);
                    Console.WriteLine("Oktaeder:  A=" + A + "  |  V=" + V);
                    break;

                default:
                    Console.WriteLine("Bitte wähle c, k, o");
                    break;
            }


        }


        //Würfel Berechnung
        public static double getCubeSurface(double Kantenlänge)
        {
            double d = Kantenlänge;
            double A = 6 * (d * d);
            //getCubeInfo(A);
            return A;
        }
        public static double getCubeVolume(double Kantenlänge)
        {
            double d = Kantenlänge;
            double V = d * d * d;
            //getCubeInfo(V);
            return V;
        }
        public static void getCubeInfo(double Kantenlänge, double A, double V)
        {
            Console.WriteLine("Würfel:  A=" + A + "  |  V=" + V);
        }

        //Kugel Berechnung
        public static double getSphereSurface(double Durchmesser)
        {
            double d = Durchmesser;
            double A = Math.PI * (d * d);
            return A;
        }
        public static double getSphereVolume(double Durchmesser)
        {
            double d = Durchmesser;
            double V = (Math.PI * (d * d * d)) / 6;
            return V;
        }

        //Okateder Berechnung
        public static double getOktaederSurface(double Kantenlänge)
        {
            double d = Kantenlänge;
            double A = 2 * Math.Sqrt(3) * (d * d);
            return A;
        }
        public static double getOktaederVolume(double Kantenlänge)
        {
            double d = Kantenlänge;
            double V = Math.Sqrt(2) * (d * d * d) / 3;
            return V;
        }
    }
}
