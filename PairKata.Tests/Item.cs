namespace PairKata.Tests;

public readonly struct Item
{
    readonly string name;
    readonly string category;

    public Item(string name, string category)
    {
        this.name = name;
        this.category = category;
    }

    public bool BelongsToCategory(string category) => this.category == category;
}