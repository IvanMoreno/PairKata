namespace PairKata.Tests;

public class Durance
{
    readonly Bag backpack;

    public Durance(Bag backpack)
    {
        this.backpack = backpack;
    }

    public void StoreItem(string iron)
    {
        backpack.AddItem(iron);
    }
}