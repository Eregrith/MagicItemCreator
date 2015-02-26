using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Helpers;
using MagicItemCreator.Tables;
using MagicItemCreator.Tables.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Creators
{
    public static class WeaponCreation
    {
        public static List<AbstractWeaponTableLine> WeaponsTable { get; set; }

        static WeaponCreation()
        {
            InitWeaponsTable();
        }

        private static void InitWeaponsTable()
        {
            WeaponsTable = new List<AbstractWeaponTableLine>
            {
                new WeaponTableLine { Minor = new Interval( 1,  70), Medium = new Interval( 1,  10), Major = null,                  AlterationBonus =  1,                 Price =   2000 },
                new WeaponTableLine { Minor = new Interval(71,  85), Medium = new Interval(11,  29), Major = null,                  AlterationBonus =  2,                 Price =   8000 },
                new WeaponTableLine { Minor = null,                  Medium = new Interval(30,  58), Major = new Interval( 1,  20), AlterationBonus =  3,                 Price =  18000 },
                new WeaponTableLine { Minor = null,                  Medium = new Interval(59,  62), Major = new Interval(21,  38), AlterationBonus =  4,                 Price =  32000 },
                new WeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval(39,  49), AlterationBonus =  5,                 Price =  50000 },
                new WeaponTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus =  6,                 Price =  72000 }, //Ces lignes sont la pour le prix et ne seront pas recuperees par un jet de dé mais au travers de l'Alteration Bonus
                new WeaponTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus =  7,                 Price =  98000 },
                new WeaponTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus =  8,                 Price = 128000 },
                new WeaponTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus =  9,                 Price = 162000 },
                new WeaponTableLine { Minor = null,                  Medium = null,                  Major = null,                  AlterationBonus = 10,                 Price = 200000 },
                new GetSpecificWeaponTableLine { Minor = new Interval(86,  90), Medium = new Interval(63,  68), Major = new Interval(50,  63) },
                new GetSpecialAbilityWeaponTableLine { Minor = new Interval(91, 100), Medium = new Interval(69, 100), Major = new Interval(64, 100) },
            };
        }

        public static MagicWeapon Create(ItemQuality quality)
        {
            int de = Dices.d100();

            AbstractWeaponTableLine ligne = WeaponsTable.GetLineFromDice(de, quality);

            return ligne.Create(quality);
        }
    }
}
