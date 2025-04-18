namespace PairKata.Tests;

public class Durance
{
    readonly Bag backpack;
    readonly List<Bag> bags;

    public Durance(Bag backpack, params Bag[] bags)
    {
        this.backpack = backpack;
        this.bags = bags.ToList();
    }

    public void StoreItem(string item)
    {
        if (backpack.IsFull())
        {
            if (bags[0].IsFull())
            {
                bags[1].AddItem(item);
                return;
            }
            bags[0].AddItem(item);
            return;
        }
            
        backpack.AddItem(item);
    }
}