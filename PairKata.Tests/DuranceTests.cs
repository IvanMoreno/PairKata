using NUnit.Framework.Internal;

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
        
        Assert.IsTrue(backpack.Any());
    }

    [Test]
    public void IfBackpackIsFullAddItemToBag()
    {
        Bag bag = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty(0), bag);
        
        sut.StoreItem(Item.Iron());
        
        Assert.IsTrue(bag.Any());
    }

    [Test]
    public void IfBackpackAndFirstBagAreFullAddItemToSecondBag()
    {
        Bag fullBag = Bag.Empty(0);
        Bag bag = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty(0), fullBag, bag);
        
        sut.StoreItem(Item.Iron());
        
        Assert.IsTrue(bag.Any());
    }
    
    [Test]
    public void SortingSpellWithOneItemDoesNotChangeAnything()
    {
        Bag backpack = Bag.Empty(1);
        Durance sut = Durance.CreateWithBackpackAndBags(backpack);
        sut.StoreItem(Item.Iron());

        sut.CastSortingSpell();
        
        Assert.IsTrue(backpack.Any());
    }

    [Test]
    public void MoveItemsToBagsWithTheirCategories()
    {
        var category = "metals";
        Bag backpack = Bag.Empty(1);
        Bag metalsBag = Bag.Empty(1, category);
        Durance sut = Durance.CreateWithBackpackAndBags(backpack, metalsBag);
        var itemInBackpack = Item.CreateInstance("Iron", category);
        sut.StoreItem(itemInBackpack);
        
        sut.CastSortingSpell();
        
        Assert.AreEqual(itemInBackpack, metalsBag.ElementAt(0));
    }
}