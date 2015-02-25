using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.CustomTypes
{
    public abstract class MagicItem
    {
        public ItemType Type { get; set; }
        public Double Price { get; set; }
        public string Name { get; set; }

        public ItemQuality Quality { get; set; }

        public MagicItem(ItemQuality quality)
        {
            this.Quality = quality;
        }

        public override abstract string ToString();
    }
}
