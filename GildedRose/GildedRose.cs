using System;
using System.Collections.Generic;
using GildedRoseKata;
namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        private const int MAX_QUALITY = 50;
        public GildedRose(IList<Item> Items) => this.Items = Items;
        private readonly Dictionary<string, Action<Item>> Products = new Dictionary<string, Action<Item>>()
        {
            {"Aged Brie",AgedBrie},
            {"Sulfuras, Hand of Ragnaros", Sulfuras},
            {"Backstage passes to a TAFKAL80ETC concert",BackStagePass},
            {"Conjured Mana Cake",ConjuredItem },
        };
        public void UpdateQuality()
        {
            foreach (var item in Items)
                (Products.TryGetValue(item.Name, out var result) ? result : RegularItem)(item);
        }
        private static void UpdateItem(Item item, int qualityChange)
        {
            item.SellIn--;
            int updatedQuality = item.Quality + qualityChange + (item.SellIn < 0 ? qualityChange : 0);
            item.Quality = Math.Max(0, Math.Min(updatedQuality, MAX_QUALITY));
        }
        private static void BackStagePass(Item item)
        {
            item.Quality += (item.SellIn <= 5) ? 3 : (item.SellIn <= 10) ? 2 : 1;
            item.SellIn--;
            if (item.SellIn < 0) item.Quality = 0;
            item.Quality = Math.Clamp(item.Quality, 0, MAX_QUALITY);
        }
        private static void AgedBrie(Item item) => UpdateItem(item, 1);
        private static void Sulfuras(Item item) { }
        private static void RegularItem(Item item) => UpdateItem(item, -1);
        private static void ConjuredItem(Item item) => UpdateItem(item, -2);
    }
}

