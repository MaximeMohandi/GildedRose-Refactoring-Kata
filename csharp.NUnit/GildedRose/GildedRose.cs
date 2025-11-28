using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            switch (item.Name)
            {
                case SpecialItem.AgedBrie:
                {
                    item.SellIn -= 1;

                    if (item.Quality < 50)
                    {
                        item.Quality += item.SellIn < 0 ? 2 : 1;
                    }
                    break;
                }
                case SpecialItem.BackstagePasses:
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;


                        if (item.SellIn < 11 && item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                        if (item.SellIn < 6 && item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }


                    item.SellIn -= 1;

                    if (item.SellIn >= 0) continue;
                    item.Quality -= item.Quality;
                    break;
                }
                case SpecialItem.Sulfuras:
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                    break;
                }
                default:
                {
                    switch (item.Quality)
                    {
                        case > 0:
                            item.Quality -= 1;
                            break;
                        case < 50:
                            item.Quality += 1;
                            break;
                    }

                    item.SellIn -= 1;
                    if (item.SellIn >= 0) continue;

                    if (item.Quality <= 0) continue;
                    item.Quality -= 1;
                    break;
                }
            }
        }
    }
}


