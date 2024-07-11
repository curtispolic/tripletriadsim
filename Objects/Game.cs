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

                string? input = Console.ReadLine();
                if (input != null)
                {
                    string[] comms = input.Split(' ');

                    if (comms.Length != 2)
                    {
                        Console.WriteLine("Incorrect number of arguments to play command (should be 2)");
                        continue;
                    }

                    if (int.TryParse(comms[0], out int cardnum))
                    {
                        string[] coords = comms[1].Split(',');
                        if (coords.Length != 2)
                        {
                            Console.WriteLine("Incorrect coordinates argument");
                            continue;
                        }
                        if (int.TryParse(coords[0], out int x) && int.TryParse(coords[1], out int y))
                        {
                            if (x < 0 || x > 2 || y < 0 || y > 2)
                            {
                                Console.WriteLine("Incorrect coordinates argument");
                                continue;
                            }
                            else
                            {
                                // Play the card then blank it in the set.
                                if (GameBoard.PlayCard(PlayerOne.Cards[cardnum], x, y))
                                {
                                    PlayerOne.Cards[cardnum] = new();
                                    PlayerOneTurn = !PlayerOneTurn;
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect move");
                                    continue;
                                }
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
                    Console.WriteLine("Null command not valid");
                }
            }
            else
            {
                while (true)
                {
                    int x = rand.Next(3);
                    int y = rand.Next(3);
                    if (GameBoard.CardList[x,y].Empty)
                    {
                        Card card = new();
                        int cardnum = 0;
                        while (card.Empty)
                        {
                            cardnum = rand.Next(5);
                            card = PlayerTwo.Cards[cardnum];
                        }
                        GameBoard.PlayCard(card, x, y);
                        PlayerTwo.Cards[cardnum] = new();
                        Console.WriteLine($"Player 2 played a card at {x},{y}");
                        PlayerOneTurn = !PlayerOneTurn;
                        break;
                    }
                }
            }
        }
        
    }
}