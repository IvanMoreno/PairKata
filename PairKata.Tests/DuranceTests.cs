using static PairKata.Tests.Item;

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

        sut.StoreItem(Iron());
        
        Assert.IsTrue(backpack.Any());
    }

    [Test]
    public void IfBackpackIsFullAddItemToBag()
    {
        Bag bag = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty(0), bag);
        
        sut.StoreItem(Iron());
        
        Assert.IsTrue(bag.Any());
    }

    [Test]
    public void IfBackpackAndFirstBagAreFullAddItemToSecondBag()
    {
        Bag fullBag = Bag.Empty(0);
        Bag bag = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty(0), fullBag, bag);
        
        sut.StoreItem(Iron());
        
        Assert.IsTrue(bag.Any());
    }
    
    [Test]
    public void SortingSpellWithOneItemDoesNotChangeAnything()
    {
        Bag backpack = Bag.WithItems(Iron());
        Durance sut = Durance.CreateWithBackpackAndBags(backpack);

        sut.CastSortingSpell();
        
        Assert.IsTrue(backpack.Any());
    }

    [Test]
    public void SortingMovesItemsToBagsWithTheirCategories()
    {
        Bag backpack = Bag.WithItems(Iron());
        Bag metalsBag = Bag.Empty(1, Iron().Category);

        Durance.CreateWithBackpackAndBags(backpack, metalsBag).CastSortingSpell();
        
        Assert.AreEqual(Iron(), metalsBag.ElementAt(0));
        Assert.IsFalse(backpack.Any());
    }
    
    [Test]
    public void SortingKeepsItemsInBackpackIfBagDoesntMatchCategory()
    {
        Bag backpack = Bag.WithItems(Iron());
        Bag clothesBag = Bag.Empty(1, Leather().Category);

        Durance.CreateWithBackpackAndBags(backpack, clothesBag).CastSortingSpell();
        
        Assert.AreEqual(Iron(), backpack.ElementAt(0));
        Assert.IsFalse(clothesBag.Any());
    }
    
    [Test]
    public void SortingKeepsItemsInBackpackIfBagDoesntHaveCategory()
    {
        Bag backpack = Bag.WithItems(Iron());
        Bag clothesBag = Bag.Empty(1, "");

        Durance.CreateWithBackpackAndBags(backpack, clothesBag).CastSortingSpell();
        
        Assert.AreEqual(Iron(), backpack.ElementAt(0));
        Assert.IsFalse(clothesBag.Any());
    }
}