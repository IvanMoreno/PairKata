namespace PairKata.Tests;

public class Bag
{
    bool isEmpty = true;
    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void AddItem(string leather)
    {
        isEmpty = false;
    }
}