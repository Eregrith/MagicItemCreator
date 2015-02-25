using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Helpers;
using MagicItemCreator.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Creators
{
    public static class MagicItemCreation
    {
        public static List<MagicItemTableLine> MagicItemsTable { get; set; }

        static MagicItemCreation()
        {
            InitMagicItemsTable();
        }

        private static void InitMagicItemsTable()
        {
            MagicItemsTable = new List<MagicItemTableLine>
            {
                new MagicItemTableLine { Minor = new Interval(1, 4), Medium = new Interval(1, 10), Major = new Interval(1, 10), Item = ItemType.ArmorAndShield, Create = ArmorCreation.Create },
                new MagicItemTableLine { Minor = new Interval(5, 9), Medium = new Interval(11, 20), Major = new Interval(11, 20), Item = ItemType.Weapon, Create = WeaponCreation.Create },
                //à compléter ...
            };
        }

        public static MagicItem Create(ItemQuality quality)
        {
            MagicItem item;

            int de = Dices.d100();

            MagicItemTableLine ligne = (MagicItemTableLine)MagicItemsTable.GetLineFromDice(de, quality);

            item = ligne.Create(quality);

            return item;
        }
    }
}
