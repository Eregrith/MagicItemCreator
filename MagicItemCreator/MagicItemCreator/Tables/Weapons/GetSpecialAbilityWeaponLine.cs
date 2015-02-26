using MagicItemCreator.Creators;
using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables.Weapons
{
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
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval(  1,  10), Medium = new Interval( 1,   6), Major = new Interval( 1,   3), Name = "Bane",             BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 11,  17), Medium = new Interval( 7,  12), Major = null,                  Name = "Defending",        BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 18,  27), Medium = new Interval(13,  19), Major = new Interval( 4,   6), Name = "Flaming",          BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 28,  37), Medium = new Interval(20,  26), Major = new Interval( 7,   9), Name = "Frost",            BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 38,  47), Medium = new Interval(27,  33), Major = new Interval(10,  12), Name = "Shock",            BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 48,  56), Medium = new Interval(34,  38), Major = new Interval(13,  15), Name = "Ghost touch",      BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 57,  67), Medium = new Interval(39,  44), Major = null,                  Name = "Keen",             BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 68,  71), Medium = new Interval(45,  48), Major = new Interval(16,  19), Name = "Ki focus",         BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 72,  75), Medium = new Interval(49,  50), Major = null,                  Name = "Merciful",         BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 76,  82), Medium = new Interval(51,  54), Major = new Interval(20,  21), Name = "Mighty cleaving",  BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 83,  87), Medium = new Interval(55,  59), Major = new Interval(22,  24), Name = "Spell storing",    BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 88,  91), Medium = new Interval(60,  63), Major = new Interval(25,  28), Name = "Throwing",         BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 92,  95), Medium = new Interval(64,  65), Major = new Interval(29,  32), Name = "Thundering",       BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 96,  99), Medium = new Interval(66,  69), Major = new Interval(33,  36), Name = "Vicious",          BaseAlterationModifier = 1 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(70,  72), Major = new Interval(37,  41), Name = "Anarchic",         BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(73,  75), Major = new Interval(42,  46), Name = "Axiomatic",        BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(76,  78), Major = new Interval(47,  49), Name = "Disruption",       BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(79,  81), Major = new Interval(50,  54), Name = "Flaming burst",    BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(82,  84), Major = new Interval(55,  59), Name = "Icy burst",        BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(85,  87), Major = new Interval(60,  64), Name = "Holy",             BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(88,  90), Major = new Interval(65,  69), Name = "Shocking burst",   BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(91,  93), Major = new Interval(70,  74), Name = "Unholy",           BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(94,  95), Major = new Interval(75,  78), Name = "Wounding",         BaseAlterationModifier = 2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(79,  83), Name = "Speed",            BaseAlterationModifier = 3 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(84,  86), Name = "Brilliant energy", BaseAlterationModifier = 4 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(87,  88), Name = "Dancing",          BaseAlterationModifier = 4 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(89,  90), Name = "Vorpal",           BaseAlterationModifier = 5 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval(100, 100), Medium = new Interval(96, 100), Major = new Interval(91, 100), Modify = RollMeleeAbilityTwice },
            };
        }

        private static void InitRangedSpecialAbilities()
        {
            RangedWeaponSpecialAbilitiesTable = new List<WeaponSpecialAbilitiesTableLine>
            {
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval(  1,  12), Medium = new Interval( 1,   8), Major = new Interval( 1,   4), Name = "Bane", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 13,  25), Medium = new Interval( 9,  16), Major = new Interval( 5,   8), Name = "Distance", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 26,  40), Medium = new Interval(17,  28), Major = new Interval( 9,  12), Name = "Flaming", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 41,  55), Medium = new Interval(29,  40), Major = new Interval(13,  16), Name = "Frost", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 56,  60), Medium = new Interval(41,  42), Major = null,                  Name = "Merciful", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 61,  68), Medium = new Interval(43,  47), Major = new Interval(17,  21), Name = "Returning", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 69,  83), Medium = new Interval(48,  59), Major = new Interval(22,  25), Name = "Shock", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 84,  93), Medium = new Interval(60,  64), Major = new Interval(26,  27), Name = "Seeking", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = new Interval( 94,  99), Medium = new Interval(65,  68), Major = new Interval(28,  29), Name = "Thundering", BaseAlterationModifier = +1 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(69,  71), Major = new Interval(30,  34), Name = "Anarchic", BaseAlterationModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(72,  74), Major = new Interval(35,  39), Name = "Axiomatic", BaseAlterationModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(75,  79), Major = new Interval(40,  49), Name = "Flaming burst", BaseAlterationModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(80,  82), Major = new Interval(50,  54), Name = "Holy", BaseAlterationModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(83,  87), Major = new Interval(55,  64), Name = "Icy burst", BaseAlterationModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(88,  92), Major = new Interval(65,  74), Name = "Shocking burst", BaseAlterationModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval(93,  95), Major = new Interval(75,  79), Name = "Unholy", BaseAlterationModifier = +2 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(80,  84), Name = "Speed", BaseAlterationModifier = +3 },
                new WeaponSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                  Major = new Interval(85,  90), Name = "Brilliant energy", BaseAlterationModifier = +4 },
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
                    baseWeapon.BasePriceModifier = ligne.BaseAlterationModifier;
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
                    baseWeapon.BasePriceModifier = ligne.BaseAlterationModifier;
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
            baseWeapon.BasePriceModifier = firstAbility.BaseAlterationModifier;

            WeaponSpecialAbilitiesTableLine secondAbility;
            do
            {
                abilityRoll = Dices.d100();

                secondAbility = MeleeWeaponSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseWeapon.Quality);

            } while (secondAbility.Modify != null //On reroll tant qu'on tombe sur un cas particulier
                     || secondAbility == firstAbility //ou sur la meme capa
                     || !AbilitiesAreCompatible(firstAbility, secondAbility) //ou sur une capa incompatible
                     || (baseWeapon.AlterationBonus + firstAbility.BaseAlterationModifier + secondAbility.BaseAlterationModifier) > 10); //ou encore que le total des alterations dépasse +10

            baseWeapon.Abilities.Add(secondAbility.Name);
            baseWeapon.BasePriceModifier += secondAbility.BaseAlterationModifier;
        }

        private static void RollRangedAbilityTwice(MagicWeapon baseWeapon)
        {
            int abilityRoll = Dices.d100();

            WeaponSpecialAbilitiesTableLine firstAbility = RangedWeaponSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseWeapon.Quality);

            if (baseWeapon.Abilities == null)
                baseWeapon.Abilities = new List<String>();

            baseWeapon.Abilities.Add(firstAbility.Name);
            baseWeapon.BasePriceModifier = firstAbility.BaseAlterationModifier;

            WeaponSpecialAbilitiesTableLine secondAbility;
            do
            {
                abilityRoll = Dices.d100();

                secondAbility = RangedWeaponSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseWeapon.Quality);

            } while (secondAbility.Modify != null //On reroll tant qu'on tombe sur un cas particulier
                     || secondAbility == firstAbility //ou sur la meme capa
                     || !AbilitiesAreCompatible(firstAbility, secondAbility) //ou sur une capa incompatible
                     || (baseWeapon.AlterationBonus + firstAbility.BaseAlterationModifier + secondAbility.BaseAlterationModifier) > 10); //ou encore que le total des alterations dépasse +10

            baseWeapon.Abilities.Add(secondAbility.Name);
            baseWeapon.BasePriceModifier += secondAbility.BaseAlterationModifier;
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
