namespace tripletriadsim.Objects;

class Game
{
    public Board GameBoard;
    public Player PlayerOne, PlayerTwo;
    public Boolean GameOver, PlayerOneTurn;

    public Game()
    {
        GameBoard = new();
        PlayerOne = new(true);
        PlayerTwo = new(false);
        GameOver = false;
        Random rand = new();
        PlayerOneTurn = rand.Next(0,2) == 1;
        while (!GameOver)
        {
            if (PlayerOneTurn)
            {
                Console.WriteLine(GameBoard.ToString());
                Console.WriteLine(PlayerOne.ToString());
                Console.WriteLine("Please input play command (<# Card to Play> <X,Y>):");
                string input = Console.ReadLine();

                string[] comms = input.Split(' ');
                if (comms.Length != 2)
                {
                    Console.WriteLine("Incorrect number of arguments to play command (should be 2)");
                    continue;
                }

                int cardnum;
                if (int.TryParse(comms[0], out cardnum))
                {
                    string[] coords = comms[1].Split(',');
                    if (coords.Length != 2)
                    {
                        Console.WriteLine("Incorrect coordinates argument");
                        continue;
                    }
                    int x, y;
                    if (int.TryParse(coords[0], out x) && int.TryParse(coords[1], out y))
                    {
                        if (x < 0 || x > 2 || y < 0 || y > 2)
                        {
                            Console.WriteLine("Incorrect coordinates argument");
                            continue;
                        }
                        else
                        {
                            GameBoard.PlayCard(PlayerOne.UnplayedCards()[cardnum-1], x, y);
                            PlayerOneTurn = !PlayerOneTurn;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect coordinates argument");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect card number argument");
                    continue;
                }
            }
            else
            {
                Console.WriteLine(GameBoard.ToString());
                Console.WriteLine(PlayerOne.ToString());
                break;
                // AI Player 2 stuffs
            }
        }
        
    }
}