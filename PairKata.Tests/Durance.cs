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
        List<Item> backpackItems = SortedItems();
        ClearStorage();
        SortItems(backpackItems);
    }

    List<Item> SortedItems() => storage.SelectMany(bag => bag).OrderBy(x => x.Name).ToList();

    private void ClearStorage()
    {
        foreach (Bag bag in storage)
        {
            bag.Clear();
        }
    }

    void SortItems(List<Item> allItems)
    {
        foreach (Item item in allItems)
        {
            FindAvailableBagFor(item).AddItem(item);
        }
    }

    Bag? FindAvailableBagFor(Item currentItem) => FindBagWithMatchingCategory(currentItem) ?? FindFirstBagWithFreeSpace();
    private Bag? FindBagWithMatchingCategory(Item currentItem) => storage.FirstOrDefault(bag => !bag.IsFull() && bag.BelongsTo(currentItem.Category));
    private Bag? FindFirstBagWithFreeSpace() => storage.OrderBy(bag => bag.HasCategory()).FirstOrDefault(bag => !bag.IsFull());
}