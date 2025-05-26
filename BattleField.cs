using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morskoy_boy
{
    class BattleField
    {
        string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        char[,] visibleArea = new char[10, 10];

        bool[,] area = new bool[10, 10];

        List<Ship> ships = new List<Ship>();

        public void Print()
        {
            string areaString = "  0 1 2 3 4 5 6 7 8 9 \n";
            for (int i = 0; i < 10; i++)
            {
                //areaString = areaString + "byak byak";
                areaString += $"{letters[i]}";
                for (int j = 0; j < 10; j++)
                {
                    if (visibleArea[i, j] == '\0')
                    {
                        visibleArea[i, j] = '~';
                    }
                    if (area[i, j] == true)
                    {
                        visibleArea[i, j] = 'O';
                    }
                        
                    areaString += $" {visibleArea[i, j]}";
                }
                areaString += "\n";
            }
            Console.WriteLine(areaString);
        }
        
        public void PlaceShips()
        {
            Ship battleShip1 = new Ship(4);
            Ship battleShip2 = new Ship(4);
            Ship destroyer1 = new Ship(3);
            Ship destroyer2 = new Ship(3);
            Ship destroyer3 = new Ship(3);
            Ship submarine1 = new Ship(2);
            Ship submarine2 = new Ship(2);
            Ship submarine3 = new Ship(2);
            Ship patrolBoat1 = new Ship(1);
            Ship patrolBoat2 = new Ship(1);
            Ship patrolBoat3 = new Ship(1);
            Ship patrolBoat4 = new Ship(1);

            ships.Add(battleShip1);
            ships.Add(battleShip2);
            ships.Add(destroyer1);
            ships.Add(destroyer2);
            ships.Add(destroyer3);
            ships.Add(submarine1);
            ships.Add(submarine2);
            ships.Add(submarine3);
            ships.Add(patrolBoat1);
            ships.Add(patrolBoat2);
            ships.Add(patrolBoat3);
            ships.Add(patrolBoat4);

            //for (int i = 0; i < ships.Count; i++)
            //{
            //    Console.WriteLine(ships[i].Horizontal);
            //}

            foreach (Ship ship in ships)
            {
                //Console.WriteLine(ship.Horizontal);
                PlaceShip(ship);
            }
        }

        void PlaceShip(Ship ship)
        {
            Random ra = new Random();

            int row, coloumn;

            while (true)
            {
                if (ship.Horizontal)
                {
                    row = ra.Next(0, 10);
                    coloumn = ra.Next(0, 11 - ship.SizeX);
                }
                else
                {
                    row = ra.Next(0, 11 - ship.SizeY);
                    coloumn = ra.Next(0, 10);
                }

                if (CheckPlacement(coloumn, row, ship) == true)
                {
                    for (int i = 0; i < ship.SizeX; i++)
                    {
                        for (int j = 0; j < ship.SizeY; j++)
                        {
                            area[coloumn + i, row + j] = true;
                            int[] coordinata = new int[] { coloumn + i, row + j };
                            ship.Coords.Add(coordinata);
                        }
                    }
                    break;
                }
            }
        }

        bool CheckPlacement(int coloumn, int row, Ship ship)
        {
            for (int i = coloumn - 1; i <= coloumn + ship.SizeX; i++)
            {
                for (int j = row - 1; j <= row + ship.SizeY; j++)
                {
                    if (i >= 0 && i < 10 && j >= 0 && j < 10)
                    {
                        if (area[i, j] == true)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
