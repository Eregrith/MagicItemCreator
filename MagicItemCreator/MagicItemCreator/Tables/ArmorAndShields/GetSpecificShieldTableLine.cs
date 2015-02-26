using MagicItemCreator.CustomTypes;
using MagicItemCreator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables.ArmorAndShields
{
    public class GetSpecificShieldTableLine : AbstractArmorAndShieldsTableLine
    {
        private static List<SpecificArmorAndShieldTableLine> SpecificShieldTable { get; set; }

        static GetSpecificShieldTableLine()
        {
            InitSpecificShieldTable();
        }

        private static void InitSpecificShieldTable()
        {
            SpecificShieldTable = new List<SpecificArmorAndShieldTableLine>
            {
                new SpecificArmorAndShieldTableLine { Minor = new Interval(01,  30), Medium = new Interval(01,  20), Major = null,                  Name = "Darkwood buckler",     Price =   203 },
                new SpecificArmorAndShieldTableLine { Minor = new Interval(31,  80), Medium = new Interval(21,  45), Major = null,                  Name = "Darkwood shield",      Price =   257 },
                new SpecificArmorAndShieldTableLine { Minor = new Interval(81,  95), Medium = new Interval(46,  70), Major = null,                  Name = "Mithral heavy shield", Price =  1020 },
                new SpecificArmorAndShieldTableLine { Minor = new Interval(96, 100), Medium = new Interval(71,  85), Major = new Interval(01,  20), Name = "Caster's shield",      Price =  3153 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = new Interval(86,  90), Major = new Interval(21,  40), Name = "Spined shield",        Price =  5580 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = new Interval(91,  95), Major = new Interval(41,  60), Name = "Lion's shield",        Price =  9170 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = new Interval(96, 100), Major = new Interval(61,  90), Name = "Winged shield",        Price = 17257 },
                new SpecificArmorAndShieldTableLine { Minor = null,                  Medium = null,                  Major = new Interval(91, 100), Name = "Absorbing shield",     Price = 50170 },
            };
        }

        public override MagicArmorAndShield Create(Enums.ItemQuality quality)
        {
            int de = Dices.d100();

            SpecificArmorAndShieldTableLine ligne = SpecificShieldTable.GetLineFromDice(de, quality);

            MagicArmorAndShield armor = new MagicArmorAndShield(quality);

            armor.Name = ligne.Name;
            armor.Price = ligne.Price;
            armor.Type = Enums.ItemType.Shield;

            return armor;
        }
    }
}
