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
        
        IEnumerable<Item> backpackItems = storage.SelectMany(bag => bag);
        ClearStorage();
        foreach (Item currentItem in backpackItems)
        {
            asldfjkhaeiruodg(currentItem).AddItem(currentItem);
        }
        
    }

    private void ClearStorage()
    {
        foreach (Bag bag in storage)
        {
            bag.Clear();
        }
    }

    public Bag asldfjkhaeiruodg( Item item )
    {
        return storage.FirstOrDefault(bag => !bag.IsFull() && bag.BelongsTo(item.Category)) ?? storage[0];
    }
}