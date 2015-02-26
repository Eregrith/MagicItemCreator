using MagicItemCreator.Creators;
using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables
{
    //Classe abstraite correspondant au tableau en general
    public abstract class AbstractWeaponTableLine : TableLine
    {
        public int AlterationBonus { get; set; }

        public int Price { get; set; }

        public abstract MagicWeapon Create(ItemQuality quality);
    }

    //Cas basique d'une arme +x avec un prix défini
    public class WeaponTableLine : AbstractWeaponTableLine
    {
        public override MagicWeapon Create(ItemQuality quality)
        {
            MagicWeapon item = new MagicWeapon(quality);

            item.Range = MagicItemCreation.ChosenRange;
            item.AlterationBonus = this.AlterationBonus;
            item.Price = this.Price;
            item.Range = MagicItemCreation.ChosenRange;
            item.Type = ItemType.Weapon;

            return item;
        }
    }

    //Cas d'une arme specifique
    public class GetSpecificWeaponTableLine : AbstractWeaponTableLine
    {
        private static List<SpecificWeaponTableLine> SpecificWeaponsTable { get; set; }

        static GetSpecificWeaponTableLine()
        {
            InitSpecificWeaponsTable();
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

        public override MagicWeapon Create(ItemQuality quality)
        {
            MagicWeapon item = new MagicWeapon(quality);

            int de = Dices.d100();

            SpecificWeaponTableLine ligne = SpecificWeaponsTable.GetLineFromDice(de, quality);

            item.Name = ligne.Name;
            item.Price = ligne.Price;
            item.Type = ItemType.Weapon; //A remplacer par ligne.PreciseType (à créer) eventuellement, pour avoir une image plus precise du type (epee longue, fleche, carreau, pal...)
            item.Range = Range.Melee; //A remplacer par ligne.Range (à créer) éventuellement.

            return item;
        }
    }

    //Cas d'une capa speciale + un reroll
    public class GetSpecialAbilityWeaponTableLine : AbstractWeaponTableLine
    {
        private static List<WeaponSpecialAbilitiesTableLine> MeleeWeaponSpecialAbilitiesTable { get; set; }
        private static List<WeaponSpecialAbilitiesTableLine> RangedWeaponSpecialAbilitiesTable { get; set; }

        static GetSpecialAbilityWeaponTableLine()
        {
            InitMeleeSpecialAbilities();
            InitRangedSpecialAbilities();
        }

        private static void InitMeleeSpecialAbilities()
        {
            MeleeWeaponSpecialAbilitiesTable = new List<WeaponSpecialAbilitiesTableLine>
            {
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval(  1,  10), Medium = new Interval( 1,   6), Major = new Interval( 1,   3), Name = "Bane",             BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 11,  17), Medium = new Interval( 7,  12), Major = null,                  Name = "Defending",        BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 18,  27), Medium = new Interval(13,  19), Major = new Interval( 4,   6), Name = "Flaming",          BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 28,  37), Medium = new Interval(20,  26), Major = new Interval( 7,   9), Name = "Frost",            BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 38,  47), Medium = new Interval(27,  33), Major = new Interval(10,  12), Name = "Shock",            BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 48,  56), Medium = new Interval(34,  38), Major = new Interval(13,  15), Name = "Ghost touch",      BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 57,  67), Medium = new Interval(39,  44), Major = null,                  Name = "Keen",             BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 68,  71), Medium = new Interval(45,  48), Major = new Interval(16,  19), Name = "Ki focus",         BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 72,  75), Medium = new Interval(49,  50), Major = null,                  Name = "Merciful",         BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 76,  82), Medium = new Interval(51,  54), Major = new Interval(20,  21), Name = "Mighty cleaving",  BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 83,  87), Medium = new Interval(55,  59), Major = new Interval(22,  24), Name = "Spell storing",    BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 88,  91), Medium = new Interval(60,  63), Major = new Interval(25,  28), Name = "Throwing",         BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 92,  95), Medium = new Interval(64,  65), Major = new Interval(29,  32), Name = "Thundering",       BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 96,  99), Medium = new Interval(66,  69), Major = new Interval(33,  36), Name = "Vicious",          BasePriceModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(70,  72), Major = new Interval(37,  41), Name = "Anarchic",         BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(73,  75), Major = new Interval(42,  46), Name = "Axiomatic",        BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(76,  78), Major = new Interval(47,  49), Name = "Disruption",       BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(79,  81), Major = new Interval(50,  54), Name = "Flaming burst",    BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(82,  84), Major = new Interval(55,  59), Name = "Icy burst",        BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(85,  87), Major = new Interval(60,  64), Name = "Holy",             BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(88,  90), Major = new Interval(65,  69), Name = "Shocking burst",   BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(91,  93), Major = new Interval(70,  74), Name = "Unholy",           BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(94,  95), Major = new Interval(75,  78), Name = "Wounding",         BasePriceModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(79,  83), Name = "Speed",            BasePriceModifier = 3 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(84,  86), Name = "Brilliant energy", BasePriceModifier = 4 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(87,  88), Name = "Dancing",          BasePriceModifier = 4 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(89,  90), Name = "Vorpal",           BasePriceModifier = 5 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval(100, 100), Medium = new Interval(96, 100), Major = new Interval(91, 100), Modify = RollMeleeAbilityTwice },
            };
        }

        private static void InitRangedSpecialAbilities()
        {
            RangedWeaponSpecialAbilitiesTable = new List<WeaponSpecialAbilitiesTableLine>
            {
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval(  1,  12), Medium = new Interval( 1,   8), Major = new Interval( 1,   4), Name = "Bane", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 13,  25), Medium = new Interval( 9,  16), Major = new Interval( 5,   8), Name = "Distance", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 26,  40), Medium = new Interval(17,  28), Major = new Interval( 9,  12), Name = "Flaming", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 41,  55), Medium = new Interval(29,  40), Major = new Interval(13,  16), Name = "Frost", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 56,  60), Medium = new Interval(41,  42), Major = null,                  Name = "Merciful", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 61,  68), Medium = new Interval(43,  47), Major = new Interval(17,  21), Name = "Returning", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 69,  83), Medium = new Interval(48,  59), Major = new Interval(22,  25), Name = "Shock", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 84,  93), Medium = new Interval(60,  64), Major = new Interval(26,  27), Name = "Seeking", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 94,  99), Medium = new Interval(65,  68), Major = new Interval(28,  29), Name = "Thundering", BasePriceModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(69,  71), Major = new Interval(30,  34), Name = "Anarchic", BasePriceModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(72,  74), Major = new Interval(35,  39), Name = "Axiomatic", BasePriceModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(75,  79), Major = new Interval(40,  49), Name = "Flaming burst", BasePriceModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(80,  82), Major = new Interval(50,  54), Name = "Holy", BasePriceModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(83,  87), Major = new Interval(55,  64), Name = "Icy burst", BasePriceModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(88,  92), Major = new Interval(65,  74), Name = "Shocking burst", BasePriceModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(93,  95), Major = new Interval(75,  79), Name = "Unholy", BasePriceModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(80,  84), Name = "Speed", BasePriceModifier = +3 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(85,  90), Name = "Brilliant energy", BasePriceModifier = +4 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval(100, 100), Medium = new Interval(96, 100), Major = new Interval(91, 100), Modify = RollRangedAbilityTwice },
            };
        }

        public override MagicWeapon Create(ItemQuality quality)
        {
            //1. Roll pour avoir l'alteration
            AbstractWeaponTableLine secondRoll;
            do
            {
                int alteration = Dices.d100();

                secondRoll = WeaponCreation.WeaponsTable.GetLineFromDice(alteration, quality);
            } while (secondRoll.GetType() != typeof(WeaponTableLine)); //On reroll tant qu'on a pas trouvé une ligne qu'on peut utiliser en tant que deuxième roll (si Create existe c'est un cas spécial et donc on ne peut pas l'utiliser)

            MagicWeapon baseWeapon = new MagicWeapon(quality);

            //On ne devrait pas avoir de cas speciaux au deuxieme roll
            baseWeapon.AlterationBonus = secondRoll.AlterationBonus;
            baseWeapon.Type = ItemType.Weapon;
            baseWeapon.Range = MagicItemCreation.ChosenRange;

            //2. Ajout de capa speciale
            //Roll sur la table des capa melee
            if (MagicItemCreation.ChosenRange == Range.Melee)
            {
                int capa = Dices.d100();

                WeaponSpecialAbilitiesTableLine ligne = MeleeWeaponSpecialAbilitiesTable.GetLineFromDice(capa, quality);

                if (ligne.Modify != null) //Cas speciaux on appelle la fonction pour modifier
                    ligne.Modify(baseWeapon);
                else //Sinon on modifie a la main
                {
                    baseWeapon.Abilities = new List<String> { ligne.Name };
                    baseWeapon.BasePriceModifier = ligne.BasePriceModifier;
                }
            }
            else //Roll sur la table des capa distance
            {
                int capa = Dices.d100();

                WeaponSpecialAbilitiesTableLine ligne = RangedWeaponSpecialAbilitiesTable.GetLineFromDice(capa, quality);

                if (ligne.Modify != null) //Cas speciaux on appelle la fonction pour modifier
                    ligne.Modify(baseWeapon);
                else //Sinon on modifie a la main
                {
                    baseWeapon.Abilities = new List<String> { ligne.Name };
                    baseWeapon.BasePriceModifier = ligne.BasePriceModifier;
                }
            }

            //3. On trouve le prix
            baseWeapon.Price = WeaponCreation.WeaponsTable.GetLineFromAlterationBonus(baseWeapon.AlterationBonus + baseWeapon.BasePriceModifier).Price;

            return baseWeapon;
        }

        private static void RollMeleeAbilityTwice(MagicWeapon baseWeapon)
        {
            int abilityRoll = Dices.d100();

            WeaponSpecialAbilitiesTableLine firstAbility = MeleeWeaponSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseWeapon.Quality);

            if (baseWeapon.Abilities == null)
                baseWeapon.Abilities = new List<String>();

            baseWeapon.Abilities.Add(firstAbility.Name);
            baseWeapon.BasePriceModifier = firstAbility.BasePriceModifier;

            WeaponSpecialAbilitiesTableLine secondAbility;
            do
            {
                abilityRoll = Dices.d100();

                secondAbility = MeleeWeaponSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseWeapon.Quality);

            } while (secondAbility.Modify != null //On reroll tant qu'on tombe sur un cas particulier
                     || secondAbility == firstAbility //ou sur la meme capa
                     || !AbilitiesAreCompatible(firstAbility, secondAbility) //ou sur une capa incompatible
                     || (baseWeapon.AlterationBonus + firstAbility.BasePriceModifier + secondAbility.BasePriceModifier) > 10); //ou encore que le total des alterations dépasse +10

            baseWeapon.Abilities.Add(secondAbility.Name);
            baseWeapon.BasePriceModifier += secondAbility.BasePriceModifier;
        }

        private static void RollRangedAbilityTwice(MagicWeapon baseWeapon)
        {
            int abilityRoll = Dices.d100();

            WeaponSpecialAbilitiesTableLine firstAbility = RangedWeaponSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseWeapon.Quality);

            if (baseWeapon.Abilities == null)
                baseWeapon.Abilities = new List<String>();

            baseWeapon.Abilities.Add(firstAbility.Name);
            baseWeapon.BasePriceModifier = firstAbility.BasePriceModifier;

            WeaponSpecialAbilitiesTableLine secondAbility;
            do
            {
                abilityRoll = Dices.d100();

                secondAbility = RangedWeaponSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseWeapon.Quality);

            } while (secondAbility.Modify != null //On reroll tant qu'on tombe sur un cas particulier
                     || secondAbility == firstAbility //ou sur la meme capa
                     || !AbilitiesAreCompatible(firstAbility, secondAbility) //ou sur une capa incompatible
                     || (baseWeapon.AlterationBonus + firstAbility.BasePriceModifier + secondAbility.BasePriceModifier) > 10); //ou encore que le total des alterations dépasse +10

            baseWeapon.Abilities.Add(secondAbility.Name);
            baseWeapon.BasePriceModifier += secondAbility.BasePriceModifier;
        }

        private static bool AbilitiesAreCompatible(WeaponSpecialAbilitiesTableLine firstAbility, WeaponSpecialAbilitiesTableLine secondAbility)
        {
            switch (firstAbility.Name) //On regarde le nom de la premiere capa
            {
                case "Holy":
                    return secondAbility.Name != "Unholy"; //Incompatible si la 2eme est Unholy

                case "Unholy":
                    return secondAbility.Name != "Holy"; //Incompatible si la 2eme est Holy

                default:
                    return true; //En general les capa sont compatibles
            }
        }
    }
}
