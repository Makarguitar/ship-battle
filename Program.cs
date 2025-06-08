namespace morskoy_boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleField area = new BattleField();
            area.PlaceShips(); 
            area.Print();
            int turns = 30;

            for(int turn = 0; turn < turns; turn++)
            {
                Console.WriteLine($"Turns left: {turns - turn}");
                Console.WriteLine($"Ships left: {area.ships.Count}");
                Console.WriteLine("Commander, where do we shoot???");
                string input = Console.ReadLine();
                Console.WriteLine($"Flatz! We shoot {input}, FIRE!");
                Console.Clear();
                if (area.ShootAtAll(input) == true)
                {
                    turn--;
                }
                area.Print();
                if (area.CheckVictory())
                {
                    Console.WriteLine("Flatz! We Have won this battle!");
                    break;
                }
            }
        }

    }
}
