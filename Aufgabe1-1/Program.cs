using System;

namespace Aufgabe01
{
    class Program
    {
        static void Main(string[] args)
        {
            var Num = args[1];
            double inputNumber = Convert.ToDouble(Num);
            switch (args[0])
            {
                case "c":
                    getCubeInfo(inputNumber);
                    break;

                case "k":
                    getSphereInfo(inputNumber);
                    break;

                case "o":
                    getOktaederInfo(inputNumber);
                    break;

                default:
                    Console.WriteLine("please choose c, k, o");
                    break;
            }
        }


        //cube
        public static double getCubeSurface(double input)
        {
            double cubesurface = 6 * (input * input);
            return cubesurface;
        }
        public static double getCubeVolume(double input)
        {
            double cubevolume = input * input * input;
            return cubevolume;
        }
        public static void getCubeInfo(double input)
        {
            Console.WriteLine("Würfel:  A=" + Math.Round(getCubeSurface(input), 2) + "  |  V=" + Math.Round(getCubeVolume(input), 2));
        }

        //sphere
        public static double getSphereSurface(double input)
        {
            double spheresurface = Math.PI * (input * input);
            return spheresurface;
        }
        public static double getSphereVolume(double input)
        {
            double spherevolume = (Math.PI * (input * input * input)) / 6;
            return spherevolume;
        }
        public static void getSphereInfo(double input)
        {
            Console.WriteLine("Kugel:  A=" + Math.Round(getSphereSurface(input), 2) + "  |  V=" + Math.Round(getSphereVolume(input), 2));
        }

        //octaeder
        public static double getOktaederSurface(double input)
        {
            double octaedersurface = 2 * Math.Sqrt(3) * (input * input);
            return octaedersurface;
        }
        public static double getOktaederVolume(double input)
        {
            double octaedervolume = Math.Sqrt(2) * (input * input * input) / 3;
            return octaedervolume;
        }
        public static void getOktaederInfo(double input)
        {
            Console.WriteLine("Oktaeder:  A=" + Math.Round(getOktaederSurface(input), 2) + "  |  V=" + Math.Round(getOktaederVolume(input), 2));
        }
    }
}
