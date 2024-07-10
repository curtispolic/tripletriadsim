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
            output += $"   {CardList[i,0].GetTop()}   |   {CardList[i,1].GetTop()}   |   {CardList[i,2].GetTop()}   \n";
            output += $" {CardList[i,0].GetLeft()}   {CardList[i,0].GetRight()} |";
            output += $" {CardList[i,1].GetLeft()}   {CardList[i,1].GetRight()} |";
            output += $" {CardList[i,2].GetLeft()}   {CardList[i,2].GetRight()} \n";
            output += $"   {CardList[i,0].GetBottom()}   |   {CardList[i,1].GetBottom()}   |   {CardList[i,2].GetBottom()}   \n";
            if (i != 2) 
            {
                output += "-----------------------\n";
            }
        }

        return output;
    }
}