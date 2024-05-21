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
        string output = "";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                output += CardList[i,j].ToString();
            }
        }

        return output;
    }
}