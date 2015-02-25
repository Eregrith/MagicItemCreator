using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables
{
    public class ArmorAndShieldsTableLine : TableLine
    {
        public int AlterationBonus { get; set; }
        public int Price { get; set; }

        public Enums.ItemType Type { get; set; }

        public delegate MagicArmorAndShield CreationFuction(ItemQuality quality);
        public CreationFuction Create { get; set; }
    }
}
