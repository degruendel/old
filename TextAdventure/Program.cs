﻿using System;
using System.Collections.Generic;

namespace TextAdventure
{
    public class Program
    {

        static void Main(string[] args)
        {

            Game _Game = new Game();

            while (_Game.isRunning)
            {
                _Game.Update();
            }

        }
    }
}