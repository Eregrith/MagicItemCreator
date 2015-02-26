using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables.ArmorAndShields
{
    public abstract class AbstractArmorAndShieldsTableLine : TableLine
    {
        public int AlterationBonus { get; set; }
        public int Price { get; set; }

        public abstract MagicArmorAndShield Create(ItemQuality quality);
    }

    public class ArmorTableLine : AbstractArmorAndShieldsTableLine
    {
        public override MagicArmorAndShield Create(ItemQuality quality)
        {
            MagicArmorAndShield item = new MagicArmorAndShield(quality);

            item.AlterationBonus = AlterationBonus;
            item.Price = Price;
            item.Type = ItemType.Armor;

            return item;
        }
    }

    public class ShieldTableLine : AbstractArmorAndShieldsTableLine
    {

        public override MagicArmorAndShield Create(ItemQuality quality)
        {
            MagicArmorAndShield item = new MagicArmorAndShield(quality);

            item.AlterationBonus = AlterationBonus;
            item.Price = Price;
            item.Type = ItemType.Shield;

            return item;
        }
    }
}
