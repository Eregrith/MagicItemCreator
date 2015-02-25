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

        //Type d'arme (utilisé si on cree une arme) : Melee ou distance
        public static Range ChosenRange { get; set; }

        static MagicItemCreation()
        {
            InitMagicItemsTable();
        }

        private static void InitMagicItemsTable()
        {
            MagicItemsTable = new List<MagicItemTableLine>
            {
                new MagicItemTableLine { Minor = new Interval( 1,   4), Medium = new Interval( 1,  10), Major = new Interval( 1,  10), Create = ArmorCreation.Create },
                new MagicItemTableLine { Minor = new Interval( 5,   9), Medium = new Interval(11,  20), Major = new Interval(11,  20), Create = WeaponCreation.Create },
                //à compléter ...
            };
        }

        public static MagicItem Create(ItemQuality quality)
        {
            MagicItem item;

            int de = Dices.d100();

            MagicItemTableLine ligne = MagicItemsTable.GetLineFromDice(de, quality);

            item = ligne.Create(quality);

            return item;
        }
    }
}
