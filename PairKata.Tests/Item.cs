namespace PairKata.Tests;

public readonly struct Item
{
    readonly string name;
    public readonly string Category;

    private Item(string name, string category)
    {
        this.name = name;
        this.Category = category;
    }

    public static Item Leather()
    {
        return CreateInstance("Leather", "clothes");
    }
    
    public static Item Iron()
    {
        return CreateInstance("Iron", "metals");
    }

    public static Item CreateInstance(string name, string category)
    {
        return new Item(name, category);
    }

    public bool BelongsToCategory(string category) => this.Category == category;
}