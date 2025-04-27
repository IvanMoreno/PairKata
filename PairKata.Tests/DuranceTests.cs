namespace PairKata.Tests;

public class DuranceTests
{
    [Test]
    public void DuranceCanBeInstantiated()
    {
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty());
        
        Assert.IsTrue(true);
    }

    [Test]
    public void DuranceStoresItemInBackpack()
    {
        Bag backpack = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(backpack);

        sut.StoreItem(Item.Iron());
        
        Assert.IsFalse(backpack.IsEmpty());
    }

    [Test]
    public void IfBackpackIsFullAddItemToBag()
    {
        Bag bag = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty(0), bag);
        
        sut.StoreItem(Item.Iron());
        
        Assert.IsFalse(bag.IsEmpty());
    }

    [Test]
    public void IfBackpackAndFirstBagAreFullAddItemToSecondBag()
    {
        Bag fullBag = Bag.Empty(0);
        Bag bag = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty(0), fullBag, bag);
        
        sut.StoreItem(Item.Iron());
        
        Assert.IsFalse(bag.IsEmpty());
    }
}