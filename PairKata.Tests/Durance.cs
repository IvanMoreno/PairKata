namespace PairKata.Tests;

public class Durance
{
    readonly List<Bag> storage;

    public Durance(Bag backpack, params Bag[] bags)
    {
        storage = new List<Bag>();
        storage.Add(backpack);
        storage.AddRange(bags);
    }

    public void StoreItem(string item)
    {
        foreach (var bag in storage)
        {
            if (bag.IsFull())
                continue;
            bag.AddItem(item);
            return;
        }
    }
}