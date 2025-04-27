using System.Collections;

namespace PairKata.Tests;

public class Bag : IEnumerable<Item>
{
    readonly int capacity;
    readonly string category;
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

    public bool IsFull()
    {
        return this.Count() == capacity;
    }

    public void AddItem(Item item)
    {
        if (IsFull())
            throw new InvalidOperationException("Cannot add item when bag is full");
            
        items.Add(item);
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