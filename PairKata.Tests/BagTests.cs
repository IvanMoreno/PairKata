namespace PairKata.Tests;

public class BagTests
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

        sut.AddItem(Item.Leather());
        
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
        
        sut.AddItem(Item.Leather());
        
        Assert.IsTrue(sut.IsFull());
    }

    [Test]
    public void BagIsNotFullUntillAllItemsHaveBeenAdded()
    {
        Bag sut = Bag.Empty(2);
        
        sut.AddItem(Item.Leather());
        
        Assert.IsFalse(sut.IsFull());
    }

    [Test]
    public void FillBagWhenAddingItemsUntilReachingCapacity()
    {
        Bag sut = Bag.Empty(2);
        
        sut.AddItem(Item.Leather());
        sut.AddItem(Item.Leather());
        
        Assert.IsTrue(sut.IsFull());
    }
}