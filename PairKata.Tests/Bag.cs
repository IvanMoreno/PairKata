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

    public bool BelongsTo(string category) => this.category == category;
    public bool HasCategory() => !string.IsNullOrEmpty(category);
    public void Clear() => items.Clear();

    public IEnumerator<Item> GetEnumerator() => items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public static Bag Empty( int capacity = 4, string category = "" )
    {
        return new Bag(capacity, category);
    }

    public static Bag WithItems(params Item[] items)
    {
        return WithItems(string.Empty, items);
    }
    
    public static Bag WithItems(string category, params Item[] items)
    {
        var result = new Bag(capacity: items.Length, category: category);
        foreach (var item in items)
        {
            result.AddItem(item);
        }

        return result;
    }
}