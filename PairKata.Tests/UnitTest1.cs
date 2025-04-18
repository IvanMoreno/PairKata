using NUnit.Framework.Internal;

namespace PairKata.Tests;
/*
 link: https://www.codurance.com/katas/bags
    - [x] we need a backpack that can have items stored.
    - [x] the backpack has capacity of 8
    - [x] we need bags that can have items stored.
    - [x] bags have capacity of 4
    - [x] items are added to the backpack
    - [x] If the backpack happens to be full, the item is added to the next available bag.
    - Items are not just strings, they have types.
    - There is a Sorting spell
    - Each bag can have a category, during the sorting spell only the items that match the category can be placed there.
         {
            "clothes": ["Leather", "Linen", "Silk", "Wool"],
            "herbs": ["Cherry Blossom", "Marigold", "Rose", "Seaweed"],
            "metals": ["Copper", "Gold", "Iron", "Silver"],
            "weapons": ["Axe", "Dagger", "Mace", "Sword"]
          }
    - Sorting spell orders alphabetically
    - When a bag with category is filled during the Sorting Spell, the backpack gets filled with the rest of the items.

 */
public class Tests
{
    [Test]
    public void IsBagEmpty()
    {
        Bag sut = Bag.Empty();
        
        Assert.IsTrue(sut.IsEmpty());
    }

    [Test]
    public void BagIsNotEmptyAfterAddingItem()
    {
        Bag sut = Bag.Empty();

        sut.AddItem("Leather");
        
        Assert.IsFalse(sut.IsEmpty());
    }

    [Test]
    public void BagIsNotFullByDefault()
    {
        Bag sut = Bag.Empty();
        
        Assert.IsFalse(sut.IsFull());
    }

    [Test]
    public void BagIsFullAfterAddingItem()
    {
        Bag sut = Bag.Empty(1);
        
        sut.AddItem("Leather");
        
        Assert.IsTrue(sut.IsFull());
    }

    [Test]
    public void BagIsNotFullUntillAllItemsHaveBeenAdded()
    {
        Bag sut = Bag.Empty(2);
        
        sut.AddItem("Leather");
        
        Assert.IsFalse(sut.IsFull());
    }

    [Test]
    public void FillBagWhenAddingItemsUntilReachingCapacity()
    {
        Bag sut = Bag.Empty(2);
        
        sut.AddItem("Leather");
        sut.AddItem("Leather");
        
        Assert.IsTrue(sut.IsFull());
    }

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

        sut.StoreItem("Iron");
        
        Assert.IsFalse(backpack.IsEmpty());
    }

    [Test]
    public void IfBackpackIsFullAddItemToBag()
    {
        Bag bag = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty(0), bag);
        
        sut.StoreItem("Iron");
        
        Assert.IsFalse(bag.IsEmpty());
    }

    [Test]
    public void IfBackpackAndFirstBagAreFullAddItemToSecondBag()
    {
        Bag fullBag = Bag.Empty(0);
        Bag bag = Bag.Empty();
        Durance sut = Durance.CreateWithBackpackAndBags(Bag.Empty(0), fullBag, bag);
        
        sut.StoreItem("Iron");
        
        Assert.IsFalse(bag.IsEmpty());
    }

    [Test]
    public void CheckItemCategory()
    {
        Item sut = new Item("Leather", "clothes");
        
        Assert.IsTrue(sut.BelongsToCategory("clothes"));
    }

    [Test]
    public void BelongOnlyToConfiguredCategory()
    {
        Item sut = new Item("Leather", "clothes");
        
        Assert.IsFalse(sut.BelongsToCategory("metals"));
    }

    [Test]
    public void ItemEquals()
    {
        Item leather = new Item("Leather", "clothes");
        Item sameLeather = new Item("Leather", "clothes");
        
        Assert.AreEqual(leather, sameLeather);
    }
    
    [Test]
    public void ItemNotEqualsByName()
    {
        Item leather = new Item("Leather", "clothes");
        Item iron = new Item("Iron", "clothes");
        
        Assert.AreNotEqual(leather, iron);
    }

    [Test]
    public void ItemNotEqualsByCategory()
    {
        Item leather = new Item("Leather", "clothes");
        Item metallicLeather = new Item("Leather", "metals");
        
        Assert.AreNotEqual(leather, metallicLeather);
    }
}