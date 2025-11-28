using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{

    [Test]
    [TestCase(1, 2, 1, 1, 0)]
    [TestCase(2, 2, 4, 0, 2)]
    [TestCase(1, -1, 4, -2, 2)]
    public void QualityAndSellInShouldDecreaseAfterUpdate(int nbDaysPassed, int sellIn, int quality, int expectedSellIn, int  expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        for (var daysPassed = 0; daysPassed < nbDaysPassed; daysPassed++)
        {
            app.UpdateQuality();
        }

        Assert.That(items[0].SellIn, Is.EqualTo(expectedSellIn));
        Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
    }

    [Test]
    public void AgedBrieIncreaseInQualityWithDaysPassing()
    {
        var  items = new List<Item> { new Item { Name = SpecialItem.AgedBrie, SellIn = 1, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(1));
    }

    [Test]
    public void QualityDecreaseTwiceAsFastWhenSellInIsPassed()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 4} };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(-2));
        Assert.That(items[0].Quality, Is.EqualTo(2));
    }

    [Test]
    public void AgedBrieQualityIncreaseTwiceAsFastWhenSellInIsPassed()
    {
        var items = new List<Item> { new Item { Name = SpecialItem.AgedBrie, SellIn = -1, Quality = 4} };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(-2));
        Assert.That(items[0].Quality, Is.EqualTo(6));
    }


    [Test]
    public void QualityOfItemIsNeverMoreThan50()
    {
        var items = new List<Item> { new Item { Name = SpecialItem.AgedBrie, SellIn = 1, Quality = 50} };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(0));
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void SulfurasNeverHasToBeSoldOrDecreaseInQuality()
    {
        var item = new List<Item> { new Item { Name = SpecialItem.Sulfuras, SellIn = 1, Quality = 50} };
        var app = new GildedRose(item);

        app.UpdateQuality();

        Assert.That(item[0].SellIn, Is.EqualTo(1));
        Assert.That(item[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void BakstagePassesIncreasedTwiceAsFastWhenSellIn10daysOrLess()
    {
        var item = new List<Item> { new Item { Name = SpecialItem.BackstagePasses, SellIn = 10, Quality = 4} };
        var app = new GildedRose(item);

        app.UpdateQuality();

        Assert.That(item[0].SellIn, Is.EqualTo(9));
        Assert.That(item[0].Quality, Is.EqualTo(6));
    }

    [Test]
    public void BackStagePassesIncreased3TimesAsFastWhenSellIn5daysOrLess()
    {
        var item = new List<Item> { new Item { Name = SpecialItem.BackstagePasses, SellIn = 5, Quality = 3} };
        var app = new GildedRose(item);

        app.UpdateQuality();

        Assert.That(item[0].SellIn, Is.EqualTo(4));
        Assert.That(item[0].Quality, Is.EqualTo(6));
    }

    [Test]
    public void BackStagePassesQualityDropToZeroWhenSellIn0days()
    {
        var item = new List<Item> { new Item { Name = SpecialItem.BackstagePasses, SellIn = 0, Quality = 40} };
        var app = new GildedRose(item);

        app.UpdateQuality();

        Assert.That(item[0].SellIn, Is.EqualTo(-1));
        Assert.That(item[0].Quality, Is.EqualTo(0));
    }
}
