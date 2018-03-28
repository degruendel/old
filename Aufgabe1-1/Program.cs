using System;

namespace Aufgabe01
{
    class Program
    {
        static void Main(string[] args)
        {
            var Num = args[1];
            double d = Convert.ToDouble(Num);
            switch (args[0])
            {
                case "c":
                    getCubeInfo(d);
                    break;

                case "k":
                    getSphereInfo(d);
                    break;

                case "o":
                    getOktaederInfo(d);
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
            return A;
        }
        public static double getCubeVolume(double Kantenlänge)
        {
            double d = Kantenlänge;
            double V = d * d * d;
            return V;
        }
        public static void getCubeInfo(double Kantenlänge)
        {
            Console.WriteLine("Würfel:  A=" + getCubeSurface(Kantenlänge) + "  |  V=" + getCubeVolume(Kantenlänge));
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
        public static void getSphereInfo(double Durchmesser)
        {
            Console.WriteLine("Kugel:  A=" + getSphereSurface(Durchmesser) + "  |  V=" + getSphereVolume(Durchmesser));
        }

        //Okateder Berechnung
        public static double getOktaederSurface(double Durchmesser)
        {
            double d = Durchmesser;
            double A = 2 * Math.Sqrt(3) * (d * d);
            return A;
        }
        public static double getOktaederVolume(double Durchmesser)
        {
            double d = Durchmesser;
            double V = Math.Sqrt(2) * (d * d * d) / 3;
            return V;
        }
        public static void getOktaederInfo(double Durchmesser)
        {
            Console.WriteLine("Oktaeder:  A=" + getOktaederSurface(Durchmesser) + "  |  V=" + getOktaederVolume(Durchmesser));
        }
    }
}
