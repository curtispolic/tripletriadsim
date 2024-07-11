namespace tripletriadsim.Objects;

class Player
{
    public Card[] Cards;
    public bool IsPlayerOne;
    public Player(bool playerOne, Card[] cardList)
    {
        IsPlayerOne = playerOne;
        Cards = cardList;
    }

    public Player(bool playerOne)
    {
        IsPlayerOne = playerOne;
        Cards = new Card[5];
        Random rand = new();
        for (int i = 0; i < 5; i++)
        {
            Cards[i] = new(rand.Next(1,11), rand.Next(1,11), rand.Next(1,11), rand.Next(1,11), IsPlayerOne);
        }
    }

    public override string ToString()
    {
        string output, line1 = "", line2 = "", line3 = "";
        output = IsPlayerOne ? "Player One Cards:\n" : "Player Two Cards:\n";
        int count = 0;
        foreach (Card card in Cards)
        {
            if (!card.Empty)
            {
                output += $"   {count}    ";
                line1 += $"   {card.GetTop()}   |";
                line2 += $" {card.GetLeft()}   {card.GetRight()} |";
                line3 += $"   {card.GetBottom()}   |";
            }
            count++;
        }
        output += "\n";
        for (int i = 0; i < line1.Length - 1; i++)
        {
            output += "-";
        }
        output += "\n" + line1.Substring(0,line1.Length-1) + "\n";
        output += line2.Substring(0,line2.Length-1) + "\n";
        output += line3.Substring(0,line3.Length-1) + "\n";
        return output;
    }
}