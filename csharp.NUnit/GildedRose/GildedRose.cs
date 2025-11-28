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
            if (item.Name == SpecialItem.AgedBrie)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;

                }

                item.SellIn -= 1;

                if (item.SellIn < 0 && item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
            else
            {
                if (item.Name == SpecialItem.BackstagePasses
                    || item.Quality <= 0
                    || item.Name == SpecialItem.Sulfuras)
                {
                    if (item.Quality >= 50)
                    {
                    }
                    else
                    {
                        item.Quality += 1;

                        if (item.Name != SpecialItem.BackstagePasses)
                        {
                        }
                        else
                        {
                            if (item.SellIn >= 11 || item.Quality >= 50)
                            {
                            }
                            else
                            {
                                item.Quality += 1;
                            }

                            if (item.SellIn >= 6 || item.Quality >= 50)
                            {
                            }
                            else
                            {
                                item.Quality += 1;
                            }
                        }
                    }
                }
                else
                {
                    item.Quality -= 1;
                }

                if (item.Name == SpecialItem.Sulfuras)
                {
                }
                else
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn >= 0) continue;
                if (item.Name == SpecialItem.AgedBrie)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
                else
                {
                    if (item.Name == SpecialItem.BackstagePasses)
                    {
                        item.Quality -= item.Quality;
                    }
                    else
                    {
                        if (item.Quality <= 0 || item.Name == SpecialItem.Sulfuras) continue;
                        item.Quality -= 1;
                    }
                }
            }
        }
    }
}
