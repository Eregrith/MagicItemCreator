using MagicItemCreator.CustomTypes;
using MagicItemCreator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables.ArmorAndShields
{
    public class GetSpecificArmorTableLine : AbstractArmorAndShieldsTableLine
    {
        private static List<SpecificArmorAndShieldTableLine> SpecificArmorTable { get; set; }

        static GetSpecificArmorTableLine()
        {
            InitSpecificArmorTable();
        }

        private static void InitSpecificArmorTable()
        {
            SpecificArmorTable = new List<SpecificArmorAndShieldTableLine>
            {
                new SpecificArmorAndShieldTableLine { Minor = new Interval(01,  50), Medium = new Interval(01,  25), Major = null,                  Name = "Mithral shirt",               Price =  1100 },
                new SpecificArmorAndShieldTableLine { Minor = new Interval(51,  80), Medium = new Interval(26,  45), Major = null,                  Name = "Dragonhide plate",            Price =  3300 },
                new SpecificArmorAndShieldTableLine { Minor = new Interval(81, 100), Medium = new Interval(46,  57), Major = null,                  Name = "Elven chain",                 Price =  5150 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = new Interval(58,  67), Major = null,                  Name = "Rhino hide",                  Price =  5165 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = new Interval(68,  82), Major = new Interval( 1,  10), Name = "Adamantine breastplate",      Price = 10200 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = new Interval(83,  97), Major = new Interval(11,  20), Name = "Dwarven plate",               Price = 16500 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = new Interval(98, 100), Major = new Interval(21,  32), Name = "Banded mail of luck",         Price = 18900 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = null,                  Major = new Interval(33,  50), Name = "Celestial armor",             Price = 22400 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = null,                  Major = new Interval(51,  60), Name = "Plate armor of the deep",     Price = 24650 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = null,                  Major = new Interval(61,  75), Name = "Breastplate of command",      Price = 25400 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = null,                  Major = new Interval(76,  90), Name = "Mithral full plate of speed", Price = 26500 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = null,                  Major = new Interval(91, 100), Name = "Demon armor",                 Price = 52260 },
            };
        }

        public override MagicArmorAndShield Create(Enums.ItemQuality quality)
        {
            int de = Dices.d100();

            SpecificArmorAndShieldTableLine ligne = SpecificArmorTable.GetLineFromDice(de, quality);

            MagicArmorAndShield armor = new MagicArmorAndShield(quality);

            armor.Name = ligne.Name;
            armor.Price = ligne.Price;
            armor.Type = Enums.ItemType.Armor;

            return armor;
        }
    }
}
