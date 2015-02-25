using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Creators
{
    public static class ArmorCreation
    {
        //public static List<ArmorTableLine> WeaponsTable { get; set; }

        static ArmorCreation()
        {
            //WeaponsTable = new List<WeaponTableLine>
            //{
            //    new ArmorTableLine { Minor = new Interval(1, 70), Medium = new Interval(1,10), Major = null, Create = WeaponCreation.CreatePlusOne },
            //    new ArmorTableLine { Minor = new Interval(71, 85), Medium = new Interval(11,29), Major = null, Create = WeaponCreation.CreatePlusTwo },
            //    //à compléter ...
            //};
        }
        public static MagicItem Create(ItemQuality quality)
        {
            throw new NotImplementedException();
        }
    }
}
