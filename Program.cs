using tripletriadsim.Objects;

class Program
{
    static void Main()
    {
        Board board = new();
        board.CardList[1,0] = new Card(8,1,5,4,true);
        board.CardList[2,0] = new Card(3,1,5,4,true);
        board.CardList[0,1] = new Card(3,1,5,4,true);
        board.CardList[1,1] = new Card(3,1,5,4,true);
        board.CardList[0,2] = new Card(3,1,5,4,true);
        board.CardList[2,2] = new Card(3,1,5,4,true);
        Card card = new Card(9, 8, 1, 6, false);
        Console.WriteLine(board.ToString());
        board.PlayCard(card, 1, 2);
        Console.WriteLine(board.ToString());
    }
}