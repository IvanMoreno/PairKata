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
        IEnumerable<Item> backpackItems = new List<Item>(backpack); 
        backpack.Clear();
        foreach (Item currentItem in backpackItems)
        {
            if (!bag.BelongsTo(currentItem.Category) || bag.IsFull())
            {
                backpack.AddItem(currentItem);
                continue;
            }
            
            bag.AddItem(currentItem);
        }
        
    }
}