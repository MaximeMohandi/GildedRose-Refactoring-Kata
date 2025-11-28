namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public int MaxQuality { get; init; } = 50;


    public void IncreaseQuality() => Quality++;
    public void IncreaseQualityTwice() =>Quality += 2;
    public void DecreaseQuality() => Quality--;
    public bool IsAtMaxQuality() =>Quality >= MaxQuality;
    public bool IsSellPassed() => SellIn < 0;
    public void DecreaseSellIn() => SellIn --;
}
