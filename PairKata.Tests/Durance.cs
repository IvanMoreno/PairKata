namespace PairKata.Tests;

public class Durance
{
    readonly List<Bag> storage;

    private Durance(List<Bag> storage)
    {
        this.storage = storage;
    }

    public static Durance CreateWithBackpackAndBags(Bag backpack, params Bag[] bags)
    {
        List<Bag> storage = new List<Bag>();
        storage.Add(backpack);
        storage.AddRange(bags);
        return new Durance(storage);
    }

    public void StoreItem(Item item)
    {
        storage.FirstOrDefault(bag => !bag.IsFull())?.AddItem(item);
    }

    public void CastSortingSpell()
    {
        if (storage.Count == 1)
        {
            return;
        }

        Bag backpack = storage[0];
        List<Item> backpackItems = new List<Item>(backpack); 
        backpackItems.AddRange(storage[1]);
        backpack.Clear();
        storage[1].Clear();
        foreach (Item currentItem in backpackItems)
        {
            asldfjkhaeiruodg(currentItem).AddItem(currentItem);
        }
        
    }

    public Bag asldfjkhaeiruodg( Item item )
    {
        return storage.FirstOrDefault(bag => !bag.IsFull() && bag.BelongsTo(item.Category)) ?? storage[0];
    }
}