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
}