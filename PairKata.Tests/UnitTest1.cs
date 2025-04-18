using NUnit.Framework.Internal;

namespace PairKata.Tests;
/*
 link: https://www.codurance.com/katas/bags
    - [x] we need a backpack that can have items stored.
    - [x] the backpack has capacity of 8
    - [x] we need bags that can have items stored.
    - [x] bags have capacity of 4
    - items are added to the backpack
    - If the backpack happens to be full, the item is added to the next available bag.
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
}