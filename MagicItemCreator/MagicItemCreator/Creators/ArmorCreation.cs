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
    public static class ArmorCreation
    {
        public static List<ArmorAndShieldsTableLine> ArmorAndShieldsTable { get; set; }
        public static List<SpecificArmorTableLine> SpecificArmorTable { get; set; }
        //public static List<SpecificShieldTableLine> SpecificShieldTable { get; set; }

        static ArmorCreation()
        {
            InitArmorAndShieldsTable();
            InitSpecificShieldTable();
            InitSpecificArmorTable();
        }

        private static void InitArmorAndShieldsTable()
        {
            ArmorAndShieldsTable = new List<ArmorAndShieldsTableLine>
            {
                new ArmorAndShieldsTableLine { Minor = new Interval( 1,  60), Medium = new Interval( 1,  05), Major = null,                  AlterationBonus = +1, Type = ItemType.Shield, Price = 1000 },
                new ArmorAndShieldsTableLine { Minor = new Interval(61,  80), Medium = new Interval( 6,  10), Major = null,                  AlterationBonus = +1, Type = ItemType.Armor, Price = 1000 },
                new ArmorAndShieldsTableLine { Minor = new Interval(81,  85), Medium = new Interval(11,  20), Major = null,                  AlterationBonus = +2, Type = ItemType.Shield, Price = 4000 },
                new ArmorAndShieldsTableLine { Minor = new Interval(86,  87), Medium = new Interval(21,  30), Major = null,                  AlterationBonus = +2, Type = ItemType.Armor, Price = 4000 },
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = new Interval(31,  40), Major = new Interval( 1,   8), AlterationBonus = +3, Type = ItemType.Shield, Price = 9000 },
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = new Interval(41,  50), Major = new Interval( 9,  16), AlterationBonus = +3, Type = ItemType.Armor, Price = 9000 },
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = new Interval(51,  55), Major = new Interval(17,  27), AlterationBonus = +4, Type = ItemType.Shield, Price = 16000 },
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = new Interval(56,  57), Major = new Interval(28,  38), AlterationBonus = +4, Type = ItemType.Armor, Price = 16000 },
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = null,                  Major = new Interval(39,  49), AlterationBonus = +5, Type = ItemType.Shield, Price = 25000 },
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = null,                  Major = new Interval(50,  57), AlterationBonus = +5, Type = ItemType.Armor, Price = 25000 },
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus = +6, Price = 36000 }, //Utilisé seulement pour le prix en fonction du bonus
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus = +7, Price = 49000 }, //Utilisé seulement pour le prix en fonction du bonus
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus = +8, Price = 64000 }, //Utilisé seulement pour le prix en fonction du bonus
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus = +9, Price = 81000 }, //Utilisé seulement pour le prix en fonction du bonus
                new ArmorAndShieldsTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus = +10,Price = 100000 }, //Utilisé seulement pour le prix en fonction du bonus
                new ArmorAndShieldsTableLine { Minor = new Interval(88,  89), Medium = new Interval(58,  60), Major = new Interval(58,  60), Create = CreateSpecificArmor },
                new ArmorAndShieldsTableLine { Minor = new Interval(90,  91), Medium = new Interval(61,  63), Major = new Interval(61,  63), Create = CreateSpecificShield },
                new ArmorAndShieldsTableLine { Minor = new Interval(92, 100), Medium = new Interval(64, 100), Major = new Interval(64, 100), Create = RollAgainWithSpecialAbility },
            };
        }

        private static void InitSpecificShieldTable()
        {

        }

        private static void InitSpecificArmorTable()
        {
            SpecificArmorTable = new List<SpecificArmorTableLine>
            {
                new SpecificArmorTableLine { Minor = new Interval(01, 50), Medium = new Interval(01, 25), Major = null, Name = "Mithral shirt", Price = 1100 },
new SpecificArmorTableLine { Minor = new Interval(51, 80), Medium = new Interval(26, 45), Major = null, Name = "Dragonhide plate", Price = 3300 },
new SpecificArmorTableLine { Minor = new Interval(81, 100), Medium = new Interval(46, 57), Major = null, Name = "Elven chain", Price = 5150 },
//—	58–67	—	Rhino hide	5,165 gp
//—	68–82	01–10	Adamantine breastplate	10,200 gp
//—	83–97	11–20	Dwarven plate	16,500 gp
//—	98–100	21–32	Banded mail of luck	18,900 gp
//—	—	33–50	Celestial armor	22,400 gp
//—	—	51–60	Plate armor of the deep	24,650 gp
//—	—	61–75	Breastplate of command	25,400 gp
//—	—	76–90	Mithral full plate of speed	26,500 gp
//—	—	91–100	Demon armor	52,260 gp
            };
        }

        private static MagicArmorAndShield RollAgainWithSpecialAbility(ItemQuality quality)
        {
            throw new NotImplementedException();
        }

        private static MagicArmorAndShield CreateSpecificShield(ItemQuality quality)
        {
            throw new NotImplementedException();
        }

        private static MagicArmorAndShield CreateSpecificArmor(ItemQuality quality)
        {
            throw new NotImplementedException();
        }

        public static MagicArmorAndShield Create(ItemQuality quality)
        {
            int de = Dices.d100();

            ArmorAndShieldsTableLine ligne = ArmorAndShieldsTable.GetLineFromDice(de, quality);

            if (ligne.Create != null)
                return ligne.Create(quality);

            MagicArmorAndShield item = new MagicArmorAndShield(quality);

            item.AlterationBonus = ligne.AlterationBonus;
            item.Price = ligne.Price;
            item.Type = ligne.Type;

            return item;
        }
    }
}
