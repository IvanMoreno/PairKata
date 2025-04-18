namespace PairKata.Tests;

public class Bag
{
    readonly int capacity;
    int itemsCount;

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
        return itemsCount == 0;
    }

    public void AddItem(string leather)
    {
        if (IsFull())
            throw new InvalidOperationException("Cannot add item when bag is full");
            
        itemsCount++;
    }

    public bool IsFull()
    {
        return itemsCount == capacity;
    }
}