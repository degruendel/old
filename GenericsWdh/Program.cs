using System;

public class Auto<Platzhalter>
{
    public double PS;
    public int Zylinder;
    public double Hubraum;
    public Platzhalter Farbe;
}

namespace GenericsWdh
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bestellwesen
            Auto<string> meinAuto = new Auto<string>();

            meinAuto.Farbe = "grau";
            meinAuto.PS = 100;
            meinAuto.Zylinder = 4;
            meinAuto.Hubraum = 2.8;
            
            //Produktion
            Auto<int> anderesAuto = new Auto<int>();
            anderesAuto.Farbe = 4711;
            
            Console.WriteLine("Hello World!");
        }
    }
}
