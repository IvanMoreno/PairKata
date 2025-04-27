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
    - [x] Items are not just strings, they have types.
    - [x] Split test class into multiple cohesive classes.
    - [x] Bags have categories.
    - [x] Obtain items from bags.
    - [x] Clean bag from items.
    - There is a Sorting spell
        - [x] Do not move items to bags that doesn't match category
        - [x] Ignore bag without category if backpack until backpack is full
    - Each bag can have a category, during the sorting spell only the items that match the category can be placed there.
         {
            "clothes": ["Leather", "Linen", "Silk", "Wool"],
            "herbs": ["Cherry Blossom", "Marigold", "Rose", "Seaweed"],
            "metals": ["Copper", "Gold", "Iron", "Silver"],
            "weapons": ["Axe", "Dagger", "Mace", "Sword"]
          }
    - Sorting spell orders alphabetically
    - When a bag with category is filled during the Sorting Spell, the backpack gets filled with the rest of the items.
    - Create type for categories
 */

public class ItemTests
{
    [Test]
    public void CheckItemCategory()
    {
        Item sut = Item.CreateInstance("Leather", "clothes");
        
        Assert.IsTrue(sut.BelongsToCategory("clothes"));
    }

    [Test]
    public void BelongOnlyToConfiguredCategory()
    {
        Item sut = Item.CreateInstance("Leather", "clothes");
        
        Assert.IsFalse(sut.BelongsToCategory("metals"));
    }

    [Test]
    public void ItemEquals()
    {
        Item leather = Item.CreateInstance("Leather", "clothes");
        Item sameLeather = Item.CreateInstance("Leather", "clothes");
        
        Assert.AreEqual(leather, sameLeather);
    }
    
    [Test]
    public void ItemNotEqualsByName()
    {
        Item leather = Item.CreateInstance("Leather", "clothes");
        Item iron = Item.CreateInstance("Iron", "clothes");
        
        Assert.AreNotEqual(leather, iron);
    }

    [Test]
    public void ItemNotEqualsByCategory()
    {
        Item leather = Item.CreateInstance("Leather", "clothes");
        Item metallicLeather = Item.CreateInstance("Leather", "metals");
        
        Assert.AreNotEqual(leather, metallicLeather);
    }
}