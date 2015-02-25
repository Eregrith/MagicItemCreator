﻿using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables
{
    public class WeaponTableLine : TableLine
    {
        public delegate MagicWeapon CreationFuction(ItemQuality quality);
        public CreationFuction Create { get; set; }

        public int AlterationBonus { get; set; }

        public int Price { get; set; }
    }
}
