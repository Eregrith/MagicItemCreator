using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Helpers;
using MagicItemCreator.Tables;
using MagicItemCreator.Tables.ArmorAndShields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Creators
{
    public static class ArmorCreation
    {
        public static List<AbstractArmorAndShieldsTableLine> ArmorAndShieldsTable { get; set; }

        static ArmorCreation()
        {
            InitArmorAndShieldsTable();
        }

        private static void InitArmorAndShieldsTable()
        {
            ArmorAndShieldsTable = new List<AbstractArmorAndShieldsTableLine>
            {
                //Cas basiques
                new ArmorTableLine  { Minor = new Interval( 1, 60), Medium = new Interval( 1, 05), Major = null,                 AlterationBonus =  +1, Price =   1000 },
                new ShieldTableLine { Minor = new Interval(61, 80), Medium = new Interval( 6, 10), Major = null,                 AlterationBonus =  +1, Price =   1000 },
                new ArmorTableLine  { Minor = new Interval(81, 85), Medium = new Interval(11, 20), Major = null,                 AlterationBonus =  +2, Price =   4000 },
                new ShieldTableLine { Minor = new Interval(86, 87), Medium = new Interval(21, 30), Major = null,                 AlterationBonus =  +2, Price =   4000 },
                new ArmorTableLine  { Minor = null,                 Medium = new Interval(31, 40), Major = new Interval( 1,  8), AlterationBonus =  +3, Price =   9000 },
                new ShieldTableLine { Minor = null,                 Medium = new Interval(41, 50), Major = new Interval( 9, 16), AlterationBonus =  +3, Price =   9000 },
                new ArmorTableLine  { Minor = null,                 Medium = new Interval(51, 55), Major = new Interval(17, 27), AlterationBonus =  +4, Price =  16000 },
                new ShieldTableLine { Minor = null,                 Medium = new Interval(56, 57), Major = new Interval(28, 38), AlterationBonus =  +4, Price =  16000 },
                new ArmorTableLine  { Minor = null,                 Medium = null,                 Major = new Interval(39, 49), AlterationBonus =  +5, Price =  25000 },
                new ShieldTableLine { Minor = null,                 Medium = null,                 Major = new Interval(50, 57), AlterationBonus =  +5, Price =  25000 },
                
                //Utilisé seulement pour le prix en fonction du bonus
                new ArmorTableLine  { AlterationBonus =  +6, Price =  36000 },
                new ArmorTableLine  { AlterationBonus =  +7, Price =  49000 },
                new ArmorTableLine  { AlterationBonus =  +8, Price =  64000 },
                new ArmorTableLine  { AlterationBonus =  +9, Price =  81000 },
                new ArmorTableLine  { AlterationBonus = +10, Price = 100000 },

                //Cas speciaux
                new GetSpecificArmorTableLine            { Minor = new Interval(88,  89), Medium = new Interval(58,  60), Major = new Interval(58,  60) },
                new GetSpecificShieldTableLine           { Minor = new Interval(90,  91), Medium = new Interval(61,  63), Major = new Interval(61,  63) },
                new GetArmorOrShieldWithAbilityTableLine { Minor = new Interval(92, 100), Medium = new Interval(64, 100), Major = new Interval(64, 100) },
            };
        }
        
        public static MagicArmorAndShield Create(ItemQuality quality)
        {
            int de = Dices.d100();

            AbstractArmorAndShieldsTableLine ligne = ArmorAndShieldsTable.GetLineFromDice(de, quality);

            return ligne.Create(quality);
        }
    }
}
