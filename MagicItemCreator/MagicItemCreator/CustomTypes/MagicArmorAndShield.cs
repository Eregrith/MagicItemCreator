using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.CustomTypes
{
    public class MagicArmorAndShield : MagicItem
    {
        public MagicArmorAndShield(ItemQuality quality)
            : base(quality)
        { }

        public int AlterationBonus { get; set; }
    }
}
