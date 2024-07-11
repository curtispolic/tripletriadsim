namespace tripletriadsim.Objects;

class Board
{
    public Card[,] CardList;

    public Board()
    {
        CardList = new Card[3,3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                CardList[i,j] = new Card();
            }
        }
    }

    public override string ToString()
    {
        string output = "     0       1       2    \n +-------+-------+-------+\n";
        for (int i = 0; i < 3; i++)
        {
            output += $" |   {CardList[0,i].GetTop()}   |   {CardList[1,i].GetTop()}   |   {CardList[2,i].GetTop()}   |\n";
            output += $"{i}| {CardList[0,i].GetLeft()} {CardList[0,i].GetPlayer()} {CardList[0,i].GetRight()} |";
            output += $" {CardList[1,i].GetLeft()} {CardList[1,i].GetPlayer()} {CardList[1,i].GetRight()} |";
            output += $" {CardList[2,i].GetLeft()} {CardList[2,i].GetPlayer()} {CardList[2,i].GetRight()} |\n";
            output += $" |   {CardList[0,i].GetBottom()}   |   {CardList[1,i].GetBottom()}   |   {CardList[2,i].GetBottom()}   |\n";
            output += " +-------+-------+-------+\n";
        }

        return output;
    }

    public int PlayedCards()
    {
        int count = 0;
        foreach (Card card in CardList)
        {
            if (!card.Empty) count++;
        }
        return count;
    }

    public bool PlayCard(Card playedCard, int x, int y)
    {
        if (CardList[x,y].Empty)
        {
            CardList[x,y] = playedCard;
            // Check if captures card to the left
            if (x != 0)
            {
                if (CardList[x-1,y].CheckIfCaptured(playedCard, "right")) CardList[x-1,y].Capture();
            }
            // Check if captures card to the right
            if (x != 2)
            {
                if (CardList[x+1,y].CheckIfCaptured(playedCard, "left")) CardList[x+1,y].Capture();
            }
            // Check if captures above
            if (y != 0)
            {
                if (CardList[x,y-1].CheckIfCaptured(playedCard, "below")) CardList[x,y-1].Capture();
            }
            // Check below
            if (y != 2)
            {
                if (CardList[x,y+1].CheckIfCaptured(playedCard, "above")) CardList[x,y+1].Capture();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}