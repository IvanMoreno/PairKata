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
        List<Item> backpackItems = storage
            .SelectMany(bag => bag)
            .OrderBy(x => x.Name)
            .ToList();
        
        ClearStorage();
        foreach (Item currentItem in backpackItems)
        {
            SortItemByCategory(currentItem);
        }
    }

    private void ClearStorage()
    {
        foreach (Bag bag in storage)
        {
            bag.Clear();
        }
    }

    private void SortItemByCategory(Item currentItem)
    {
        var storage = FindBagWithMatchingCategory(currentItem) ?? FindFirstBagWithFreeSpace();
        storage.AddItem(currentItem);
    }

    private Bag? FindBagWithMatchingCategory(Item currentItem)
    {
        return storage.FirstOrDefault(bag => !bag.IsFull() && bag.BelongsTo(currentItem.Category));
    }

    private Bag? FindFirstBagWithFreeSpace()
    {
        return storage.OrderBy(bag => bag.HasCategory()).FirstOrDefault(bag => !bag.IsFull());
    }
}