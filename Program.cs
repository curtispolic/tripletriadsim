using tripletriadsim.Objects;

class Program
{
    static void Main()
    {
        Board board = new();
        board.CardList[0,0] = new Card(3,1,5,4,true);
        Console.WriteLine(board.ToString());
    }
}