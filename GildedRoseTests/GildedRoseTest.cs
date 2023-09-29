using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using csharp;
using Xunit.Abstractions;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "fixme", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);

            
        }

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },

                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                          

    };

        [Fact]
        public void Test()
        {
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[7].SellIn);
            Assert.Equal(50, Items[7].Quality);

        }
        [Fact]
        public void Day15()
        {
            var app = new GildedRose(Items);
            for (int i = 0; i < 15; i++)
            app.UpdateQuality();
            Assert.Equal(0, Items[3].SellIn);
            Assert.Equal(80, Items[3].Quality);

        }

        [Fact]
        public void Day30()
        {
            var app = new GildedRose(Items);
            for (int i = 0; i < 30; i++)
                app.UpdateQuality();
            Assert.Equal(-20, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);

            Assert.Equal(-25, Items[7].SellIn);
            Assert.Equal(0, Items[7].Quality);

        }
        

    }
}
