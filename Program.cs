﻿namespace morskoy_boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleField area = new BattleField();
            area.PlaceShips(); 
            area.Print();
        }

    }
}
