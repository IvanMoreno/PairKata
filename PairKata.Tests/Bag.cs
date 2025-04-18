namespace PairKata.Tests;

public class Bag
{
    bool isEmpty = true;
    int capacity;

    private Bag(int capacity)
    {
        this.capacity = capacity;
    }

    public static Bag Empty( int capacity = 4 )
    {
        return new Bag(capacity);
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void AddItem(string leather)
    {
        isEmpty = false;
    }

    public bool IsFull()
    {
        return !isEmpty && capacity == 1;
    }
}