using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _store;

    public GildedRose(IList<Item> store)
    {
        _store = store;
    }



    public void UpdateQuality()
    {
        foreach (var item in _store)
        {
            switch (item.Name)
            {
                case SpecialItem.AgedBrie:
                {
                    item.DecreaseSellIn();

                    if (item.IsAtMaxQuality()) continue;

                    if (item.IsSellPassed())
                    {
                        item.IncreaseQualityTwice();
                    }
                    else
                    {
                        item.IncreaseQuality();
                    }

                    break;
                }
                case SpecialItem.BackstagePasses:
                {
                    if (item.Quality < 50)
                    {
                        item.IncreaseQuality();


                        if (item.SellIn < 11 && item.Quality < 50)
                        {
                            item.IncreaseQuality();
                        }
                        if (item.SellIn < 6 && item.Quality < 50)
                        {
                            item.IncreaseQuality();
                        }
                    }


                    item.DecreaseSellIn();

                    if (item.SellIn >= 0) continue;
                    item.Quality -= item.Quality;
                    break;
                }
                case SpecialItem.Sulfuras:
                {
                    if (item.Quality < 50)
                    {
                        item.IncreaseQuality();
                    }
                    break;
                }
                default:
                {
                    switch (item.Quality)
                    {
                        case > 0:
                            item.DecreaseQuality();
                            break;
                        case < 50:
                            item.IncreaseQuality();
                            break;
                    }

                    item.SellIn -= 1;
                    if (item.SellIn >= 0) continue;

                    if (item.Quality <= 0) continue;
                    item.DecreaseQuality();
                    break;
                }
            }
        }
    }
}


