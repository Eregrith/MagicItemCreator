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
    public static class WeaponCreation
    {
        public static List<WeaponTableLine> WeaponsTable { get; set; }
        public static List<SpecificWeaponTableLine> SpecificWeaponsTable { get; set; }

        static WeaponCreation()
        {
            InitWeaponsTable();
            InitSpecificWeaponsTable();
        }

        private static void InitWeaponsTable()
        {
            WeaponsTable = new List<WeaponTableLine>
            {
                new WeaponTableLine { Minor = new Interval( 1,  70), Medium = new Interval( 1,  10), Major = null,                  Create = CreatePlusOne },
                new WeaponTableLine { Minor = new Interval(71,  85), Medium = new Interval(11,  29), Major = null,                  Create = CreatePlusTwo },
                new WeaponTableLine { Minor = null,                  Medium = new Interval(30,  58), Major = new Interval( 1,  20), Create = CreatePlusThree },
                new WeaponTableLine { Minor = null,                  Medium = new Interval(59,  62), Major = new Interval(21,  38), Create = CreatePlusFour },
                new WeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval(39,  49), Create = CreatePlusFive },
                new WeaponTableLine { Minor = new Interval(86,  90), Medium = new Interval(63,  68), Major = new Interval(50,  63), Create = CreateSpecific },
                new WeaponTableLine { Minor = new Interval(91, 100), Medium = new Interval(69, 100), Major = new Interval(64, 100), Create = CreateWithAbilityAndReroll },
            };
        }

        private static void InitSpecificWeaponsTable()
        {
            SpecificWeaponsTable = new List<SpecificWeaponTableLine>
            {
                new SpecificWeaponTableLine { Minor = new Interval( 1,  15), Medium = null,                  Major = null,                   Name = "Sleep arrow",                     Price =    132 },
                new SpecificWeaponTableLine { Minor = new Interval(16,  25), Medium = null,                  Major = null,                   Name = "Screaming bolt",                  Price =    267 },
                new SpecificWeaponTableLine { Minor = new Interval(26,  45), Medium = null,                  Major = null,                   Name = "Silver dagger, masterwork",       Price =    322 },
                new SpecificWeaponTableLine { Minor = new Interval(46,  65), Medium = null,                  Major = null,                   Name = "Cold iron longsword, masterwork", Price =    330 },
                new SpecificWeaponTableLine { Minor = new Interval(66,  75), Medium = new Interval( 1,   9), Major = null,                   Name = "Javelin of lightning",            Price =   1500 },
                new SpecificWeaponTableLine { Minor = new Interval(76,  80), Medium = new Interval(10,  15), Major = null,                   Name = "Slaying arrow",                   Price =   2282 },
                new SpecificWeaponTableLine { Minor = new Interval(81,  90), Medium = new Interval(16,  24), Major = null,                   Name = "Adamantine dagger",               Price =   3002 },
                new SpecificWeaponTableLine { Minor = new Interval(91, 100), Medium = new Interval(25,  33), Major = null,                   Name = "Adamantine battleaxe",            Price =   3010 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(34,  37), Major = null,                   Name = "Slaying arrow (greater)",         Price =   4057 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(38,  40), Major = null,                   Name = "Shatterspike",                    Price =   4315 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(41,  46), Major = null,                   Name = "Dagger of venom",                 Price =   8302 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(47,  51), Major = null,                   Name = "Trident of warning",              Price =  10115 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(52,  57), Major = new Interval(  1,   4), Name = "Assassin's dagger",               Price =  10302 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(58,  62), Major = new Interval(  5,   7), Name = "Shifter's sorrow",                Price =  12780 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(63,  66), Major = new Interval(  8,   9), Name = "Trident of fish command",         Price =  18650 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(67,  74), Major = new Interval( 10,  13), Name = "Flame tongue",                    Price =  20715 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(75,  79), Major = new Interval( 14,  17), Name = "Luck blade (0 wishes)",           Price =  22060 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(80,  86), Major = new Interval( 18,  24), Name = "Sword of subtlety",               Price =  22310 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(87,  91), Major = new Interval( 25,  31), Name = "Sword of the planes",             Price =  22315 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(92,  95), Major = new Interval( 32,  37), Name = "Nine lives stealer",              Price =  23057 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(96,  98), Major = new Interval( 38,  42), Name = "Oathbow",                         Price =  25600 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = new Interval(99, 100), Major = new Interval( 43,  46), Name = "Sword of life stealing",          Price =  25715 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 47,  51), Name = "Mace of terror",                  Price =  38552 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 52,  57), Name = "Life-drinker",                    Price =  40320 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 58,  62), Name = "Sylvan scimitar",                 Price =  47315 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 63,  67), Name = "Rapier of puncturing",            Price =  50320 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 68,  73), Name = "Sun blade",                       Price =  50335 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 74,  79), Name = "Frost brand",                     Price =  54475 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 80,  84), Name = "Dwarven thrower",                 Price =  60312 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 85,  91), Name = "Luck blade (1 wish)",             Price =  62360 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 92,  95), Name = "Mace of smiting",                 Price =  75312 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 96,  97), Name = "Luck blade (2 wishes)",           Price = 102660 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval( 98,  99), Name = "Holy avenger",                    Price = 120630 },
                new SpecificWeaponTableLine { Minor = null,                  Medium = null,                  Major = new Interval(100, 100), Name = "Luck blade (3 wishes)",           Price = 142960 },
            };
        }

        public static MagicItem Create(ItemQuality quality)
        {
            MagicItem item;

            int de = Dices.d100();

            WeaponTableLine ligne = (WeaponTableLine)WeaponsTable.GetLineFromDice(de, quality);

            item = ligne.Create(quality);

            return item;
        }

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

        private static MagicItem CreatePlusThree(ItemQuality quality)
        {
            MagicWeapon item = new MagicWeapon();

            item.AlterationBonus = 3;
            item.Price = 18000;

            return item;
        }

        private static MagicItem CreatePlusFour(ItemQuality quality)
        {
            MagicWeapon item = new MagicWeapon();

            item.AlterationBonus = 4;
            item.Price = 32000;

            return item;
        }

        private static MagicItem CreatePlusFive(ItemQuality quality)
        {
            MagicWeapon item = new MagicWeapon();

            item.AlterationBonus = 5;
            item.Price = 50000;

            return item;
        }

        private static MagicItem CreateSpecific(ItemQuality quality)
        {
            throw new NotImplementedException();
        }

        private static MagicItem CreateWithAbilityAndReroll(ItemQuality quality)
        {
            throw new NotImplementedException();
        }
    }
}
