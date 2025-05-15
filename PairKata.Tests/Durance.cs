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
        List<Item> backpackItems = storage.SelectMany(bag => bag).ToList();
        ClearStorage();
        foreach (Item currentItem in backpackItems)
        {
            bghuweriohg(currentItem);
        }
    }

    private void alghir(Item item)
    {
        var availableBag = storage.OrderBy(bag => bag.HasCategory()).FirstOrDefault(bag => !bag.IsFull());
        availableBag.AddItem(item);
    }

    private void bghuweriohg(Item currentItem)
    {
        var storageWithCategory = storage.FirstOrDefault(bag => !bag.IsFull() && bag.BelongsTo(currentItem.Category));
        if (storageWithCategory == null)
        {
            alghir(currentItem);
            return;
        }
        storageWithCategory.AddItem(currentItem);
    }

    private void ClearStorage()
    {
        foreach (Bag bag in storage)
        {
            bag.Clear();
        }
    }
}