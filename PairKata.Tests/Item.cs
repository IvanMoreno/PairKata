namespace PairKata.Tests;

public readonly struct Item
{
    public readonly string Name;
    public readonly string Category;

    private Item(string name, string category)
    {
        this.Name = name;
        this.Category = category;
    }

    public static Item Leather() => CreateInstance("Leather", "clothes");
    public static Item Iron() => CreateInstance("Iron", "metals");
    public static Item Gold() => CreateInstance("Gold", "metals");
    public static Item Dagger() => CreateInstance("Dagger", "weapons");

    public static Item CreateInstance(string name, string category)
    {
        return new Item(name, category);
    }

    public bool BelongsToCategory(string category) => this.Category == category;

    public override string ToString()
    {
        return $"{Name} with category {Category}";
    }
}