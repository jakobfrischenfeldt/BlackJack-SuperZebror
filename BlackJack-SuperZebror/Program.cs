class Program
{
    static void Main(string[] args)
    {
        bool showMenu = true;

        while (showMenu)
        {
            Console.Clear();

            Console.WriteLine("-------Black Jack-------");
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. Leader board");
            Console.WriteLine("3. Rules");
            Console.WriteLine("4. Quit");
            Console.Write("Choice:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //Skapar ett spelobjekt och startar spelet
                    Game game = new Game();
                    game.Play();
                    break;
                case "2":
                    //Skpar ett LeaderBoard-objekt och visar leader board
                    LeaderBoard leaderBoard = new LeaderBoard();
                    leaderBoard.ShowLeaderBoard();
                    break;
                case "3":
                    //Skapar ett Rules-objekt och visar reglerna
                    Rules rules = new Rules();
                    rules.ShowRules();
                    break;
                case "4":
                    //Avslutar programmet
                    showMenu = false;
                    Console.WriteLine("Thank you for playing!");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}