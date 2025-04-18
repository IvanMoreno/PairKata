namespace PairKata.Tests;
/*
 link: https://www.codurance.com/katas/bags
    - we need a backpack that can have items stored.
    - the backpack has capacity of 8
    - we need bags that can have items stored.
    - bags have capacity of 4
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
        Bag sut = new Bag();
        
        Assert.IsTrue(sut.IsEmpty());
    }
}