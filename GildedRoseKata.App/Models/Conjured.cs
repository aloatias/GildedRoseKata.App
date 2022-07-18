﻿using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class Conjured : ItemBase, IItem
    {
        public Conjured()
        {
            Name = "Conjured";
        }

        public void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 1;
            }

            Sellin -= 1;

            if (Sellin < 0 && Quality > 0)
            {
                Quality -= 1;
            }
        }
    }
}
