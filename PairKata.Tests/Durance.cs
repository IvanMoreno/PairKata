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
        Bag bag = storage[1];
        foreach (Item currentItem in backpack)
        {
            if (!bag.BelongsTo(currentItem.Category))
                return;
            
            bag.AddItem(currentItem);
        }
        backpack.Clear();
        
    }
}