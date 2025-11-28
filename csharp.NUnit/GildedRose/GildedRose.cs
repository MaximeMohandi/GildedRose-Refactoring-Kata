using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public partial class GildedRose
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
            ComputeItemQuality(item);
        }
    }

    private static void ComputeItemQuality(Item item)
    {
        switch (item.Name)
        {
            case SpecialItem.AgedBrie:
            {
                item.DecreaseSellIn();

                if (item.IsAtMaxQuality()) break;

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
                if (!item.IsAtMaxQuality())
                {
                    item.IncreaseQuality();


                    if (item.SellIn < 11 && !item.IsAtMaxQuality())
                    {
                        item.IncreaseQuality();
                    }
                    if (item.SellIn < 6 && !item.IsAtMaxQuality())
                    {
                        item.IncreaseQuality();
                    }
                }

                item.DecreaseSellIn();

                if (!item.IsSellPassed()) return;
                item.Quality -= item.Quality;
                break;
            }
            case SpecialItem.Sulfuras:
            {
                if (item.IsAtMaxQuality()) return;

                item.IncreaseQuality();

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

                item.DecreaseSellIn();
                if (!item.IsSellPassed()) return;

                if (item.Quality <= 0) return;
                item.DecreaseQuality();
                break;
            }
        }
    }
}


