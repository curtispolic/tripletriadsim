class Card
{
    public int Top, Left, Right, Bottom;
    public bool OwnedByPlayerOne;

    public Card(int top, int left, int right, int bottom, bool playerOne)
    {
        Top = top;
        Left = left;
        Right = right;
        Bottom = bottom;
        OwnedByPlayerOne = playerOne;
    }

    public bool CheckIfCaptured(Card opponent, string opponentRelativePos)
    {
        switch (opponentRelativePos)
        {
            case "above":
                return opponent.Bottom > Top;
            case "right":
                return opponent.Left > Right;
            case "left":
                return opponent.Right > Left;
            case "below":
                return opponent.Top > Bottom;
            default:
                throw new Exception("Incorrect Relative Pos String");
        }
    }

    public void Capture()
    {
        OwnedByPlayerOne = !OwnedByPlayerOne;
    }

    public override string ToString()
    {
        return $"  {Top}  \n{Left}   {Right}\n  {Bottom}  ";
    }
}
