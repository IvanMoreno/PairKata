using System.Collections;

namespace PairKata.Tests;

public class Bag : IEnumerable<Item>
{
    readonly int capacity;
    readonly string category;
    int itemsCount;
    readonly List<Item> items = new();

    private Bag(int capacity, string category)
    {
        this.capacity = capacity;
        this.category = category;
    }

    public static Bag Empty( int capacity = 4, string category = "" )
    {
        return new Bag(capacity, category);
    }

    public bool IsEmpty()
    {
        return itemsCount == 0;
    }

    public bool IsFull()
    {
        return itemsCount == capacity;
    }

    public void AddItem(Item item)
    {
        if (IsFull())
            throw new InvalidOperationException("Cannot add item when bag is full");
            
        items.Add(item);
        itemsCount++;
    }

    public bool BelongsTo(string category)
    {
        return this.category == category;
    }

    public IEnumerator<Item> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}