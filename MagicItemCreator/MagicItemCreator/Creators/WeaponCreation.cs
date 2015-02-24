using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Creators
{
    public static class WeaponCreation
    {
        public static MagicItem CreatePlusOne(Enums.ItemQuality quality)
        {
            MagicWeapon item = new MagicWeapon();

            item.AlterationBonus = 1;
            item.Price = 2000;

            return item;
        }

        public static MagicItem CreatePlusTwo(Enums.ItemQuality quality)
        {
            MagicWeapon item = new MagicWeapon();

            item.AlterationBonus = 2;
            item.Price = 8000;

            return item;
        }
    }
}
