using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables
{
    public class WeaponTableLine : TableLine
    {
        public delegate MagicItem CreationFuction(ItemQuality quality);
        public CreationFuction Create { get; set; }
    }
}
