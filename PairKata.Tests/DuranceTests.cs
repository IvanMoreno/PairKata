using NUnit.Framework.Internal;
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
    
    [Test]
    public void SortingMovesAllItemsToBagWithTheirCategory()
    {
        Bag backpack = Bag.WithItems(Iron(), Iron());
        Bag metalsBag = Bag.Empty(2, Iron().Category);

        Durance.CreateWithBackpackAndBags(backpack, metalsBag).CastSortingSpell();
        
        Assert.AreEqual(2, metalsBag.Count());
        Assert.IsFalse(backpack.Any());
    }
    
    [Test]
    public void SortingMovesAllItemsToBagWithTheirCategoryUntilFull()
    {
        Bag backpack = Bag.WithItems(Iron(), Iron());
        Bag metalsBag = Bag.Empty(1, Iron().Category);

        Durance.CreateWithBackpackAndBags(backpack, metalsBag).CastSortingSpell();
        
        Assert.AreEqual(1, metalsBag.Count());
        Assert.AreEqual(1, backpack.Count());
    }
    
    [Test]
    public void SortingMovesAllItemsToCategorizedBags()
    {
        Bag backpack = Bag.WithItems(Iron(), Leather());
        Bag metalsBag = Bag.Empty(1, Iron().Category);
        Bag clothesBag = Bag.Empty(1, Leather().Category);

        Durance.CreateWithBackpackAndBags(backpack, metalsBag, clothesBag).CastSortingSpell();
        
        Assert.AreEqual(1, metalsBag.Count());
        Assert.AreEqual(1, clothesBag.Count());
        Assert.IsFalse(backpack.Any());
    }
    
    [Test]
    public void SortingMovesMovesToBackpackIfBagDoesntHaveCategory()
    {
        Bag backpack = Bag.Empty();
        Bag nonCategoryBag = Bag.WithItems(Iron());

        Durance.CreateWithBackpackAndBags(backpack,nonCategoryBag).CastSortingSpell();
        
        Assert.AreEqual(1, backpack.Count());
        Assert.IsFalse(nonCategoryBag.Any());
    }
    
    [Test]
    public void SortItemsStoredInAllBags()
    {
        Bag backpack = Bag.WithItems(Iron());
        Bag metalsBag = Bag.Empty(1, Iron().Category);
        Bag nonCategorizedBag = Bag.WithItems(Leather());

        Durance.CreateWithBackpackAndBags(backpack, metalsBag, nonCategorizedBag).CastSortingSpell();
        
        Assert.AreEqual(Leather(), backpack.Single());
        Assert.IsFalse(nonCategorizedBag.Any());
        Assert.AreEqual(Iron(), metalsBag.Single());
    }
    
    [Test]
    public void SortItemsInAvailableNonCategorizedBagIfBackpackIsFull()
    {
        Bag backpack = Bag.WithItems(Iron());
        Bag nonCategorizedBag = Bag.WithItems(Leather());
        
        Durance.CreateWithBackpackAndBags(backpack, nonCategorizedBag).CastSortingSpell();
        
        Assert.AreEqual(1, backpack.Count());
        Assert.AreEqual(1, nonCategorizedBag.Count());
    }

    [Test]
    public void SortingFillsNonCategorizedBagsWhenBackpackIsFull()
    {
        Bag backpack = Bag.WithItems(Leather());
        Bag metalsBag = Bag.Empty(category: Iron().Category);
        Bag nonCategorizedBag = Bag.WithItems(Leather());
        
        Durance.CreateWithBackpackAndBags(backpack, metalsBag, nonCategorizedBag).CastSortingSpell();
        
        Assert.AreEqual(1, backpack.Count());
        Assert.AreEqual(0, metalsBag.Count());
        Assert.AreEqual(1, nonCategorizedBag.Count());
    }

    [Test]
    public void SortingFillsUnMatchingCategoriesBagsWhenThereAreNoMoreBags()
    {
        Bag backpack = Bag.WithItems(Leather());
        Bag metalsBag = Bag.WithItems(Iron().Category, Leather());
        
        Durance.CreateWithBackpackAndBags(backpack, metalsBag).CastSortingSpell();
        
        Assert.AreEqual(1, backpack.Count());
        Assert.AreEqual(1, metalsBag.Count());
    }
    
    [Test]
    public void SortItemsAlphabetically()
    {
        Bag backpack = Bag.WithItems(Leather(), Iron());
        
        Durance.CreateWithBackpackAndBags(backpack).CastSortingSpell();
        
        Assert.AreEqual(Iron(), backpack.First());
        Assert.AreEqual(Leather(), backpack.Last());
    }

    [Test]
    public void SortItemsAlphabeticallyInSeveralBags()
    {
        Bag backpack = Bag.WithItems(Leather(), Iron(), Gold(), Dagger());
        Bag metalsBag = Bag.Empty(category: Iron().Category);
        
        Durance.CreateWithBackpackAndBags(backpack, metalsBag).CastSortingSpell();
        
        Assert.AreEqual(Gold(), metalsBag.First());
        Assert.AreEqual(Iron(), metalsBag.Last());
        Assert.AreEqual(Dagger(), backpack.First());
        Assert.AreEqual(Leather(), backpack.Last());
    }
}