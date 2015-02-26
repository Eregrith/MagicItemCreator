using MagicItemCreator.Creators;
using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables.ArmorAndShields
{
    public class GetArmorOrShieldWithAbilityTableLine : AbstractArmorAndShieldsTableLine
    {
        private static List<ArmorAndShieldSpecialAbilitiesTableLine> ArmorSpecialAbilitiesTable { get; set; }
        private static List<ArmorAndShieldSpecialAbilitiesTableLine> ShieldSpecialAbilitiesTable { get; set; }

        static GetArmorOrShieldWithAbilityTableLine()
        {
            InitArmorSpecialAbilities();
            InitShieldSpecialAbilities();
        }

        private static void InitShieldSpecialAbilities()
        {
            ShieldSpecialAbilitiesTable = new List<ArmorAndShieldSpecialAbilitiesTableLine>
            {
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(01, 20), Medium =  new Interval(01, 10), Major = new Interval(01, 05), Name = "Arrow catching", BaseAlterationModifier = 1 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(21, 40), Medium =  new Interval(11, 20), Major = new Interval(06, 08), Name = "Bashing", BaseAlterationModifier = 1 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(41, 50), Medium =  new Interval(21, 25), Major = new Interval(09, 10), Name = "Blinding", BaseAlterationModifier = 1 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(51, 75), Medium =  new Interval(26, 40), Major = new Interval(11, 15), Name = "Fortification, light", BaseAlterationModifier = 1 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(76, 92), Medium =  new Interval(41, 50), Major = new Interval(16, 20), Name = "Arrow deflection", BaseAlterationModifier = 2 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(93, 97), Medium =  new Interval(51, 57), Major = new Interval(21, 25), Name = "Animated", BaseAlterationModifier = 2 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(98, 99), Medium =  new Interval(58, 59), Major = null, Name = "Spell resistance (13)", BaseAlterationModifier = 2 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  new Interval(60, 79), Major = new Interval(26, 41), Name = "Energy resistance", BasePriceModifier = 18000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  new Interval(80, 85), Major = new Interval(42, 46), Name = "Ghost touch", BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  new Interval(86, 95), Major = new Interval(47, 56), Name = "Fortification, moderate", BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  new Interval(96, 98), Major = new Interval(57, 58), Name = "Spell resistance (15)", BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  new Interval(99, 99), Major = new Interval(59, 59), Name = "Wild", BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  null, Major = new Interval(60, 84), Name = "Energy resistance, improved", BasePriceModifier = 42000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  null, Major = new Interval(85, 86), Name = "Spell resistance (17)", BaseAlterationModifier = 4 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  null, Major = new Interval(87, 87), Name = "Undead controlling", BasePriceModifier = 49000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  null, Major = new Interval(88, 91), Name = "Fortification, heavy", BaseAlterationModifier = 5 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  null, Major = new Interval(92, 93), Name = "Reflecting", BaseAlterationModifier = 5 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  null, Major = new Interval(94, 94), Name = "Spell resistance (19)", BaseAlterationModifier = 5 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null, Medium =  null, Major = new Interval(95, 99), Name = "Energy resistance, greater", BasePriceModifier = 66000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(100, 100), Medium = new Interval(100, 100), Major = new Interval(100, 100), Modify = RollShieldAbilityTwice },
            };
        }

        private static void InitArmorSpecialAbilities()
        {
            ArmorSpecialAbilitiesTable = new List<ArmorAndShieldSpecialAbilitiesTableLine>
            {
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(  1,  25), Medium = new Interval(  1,   5), Major = new Interval(  1,   3), Name = "Glamered",                    BasePriceModifier =  2700 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval( 26,  32), Medium = new Interval(  6,   8), Major = new Interval(  4,   4), Name = "Fortification, light",        BaseAlterationModifier = 1 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval( 33,  52), Medium = new Interval(  9,  11), Major = null,                   Name = "Slick",                       BasePriceModifier =  3750 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval( 53,  92), Medium = new Interval( 12,  17), Major = null,                   Name = "Shadow",                      BasePriceModifier =  3750 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval( 93,  96), Medium = new Interval( 18,  19), Major = null,                   Name = "Spell resistance (13)",       BaseAlterationModifier = 2 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval( 97,  97), Medium = new Interval( 20,  29), Major = new Interval(  5,   7), Name = "Slick, improved",             BasePriceModifier = 15000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval( 98,  99), Medium = new Interval( 30,  49), Major = new Interval(  8,  13), Name = "Shadow, improved",            BasePriceModifier = 15000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval( 50,  74), Major = new Interval( 14,  28), Name = "Energy resistance",           BasePriceModifier = 18000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval( 75,  79), Major = new Interval( 29,  33), Name = "Ghost touch",                 BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval( 80,  84), Major = new Interval( 34,  35), Name = "Invulnerability",             BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval( 85,  89), Major = new Interval( 36,  40), Name = "Fortification, moderate",     BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval( 90,  94), Major = new Interval( 41,  42), Name = "Spell resistance (15)",       BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = new Interval( 95,  99), Major = new Interval( 43,  43), Name = "Wild",                        BaseAlterationModifier = 3 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 44,  48), Name = "Slick, greater",              BasePriceModifier = 33750 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 49,  58), Name = "Shadow, greater",             BasePriceModifier = 33750 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 59,  83), Name = "Energy resistance, improved", BasePriceModifier = 42000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 84,  88), Name = "Spell resistance (17)",       BaseAlterationModifier = 4 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 89,  89), Name = "Etherealness",                BasePriceModifier = 49000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 90,  90), Name = "Undead controlling",          BasePriceModifier = 49000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 91,  92), Name = "Fortification, heavy",        BaseAlterationModifier = 5 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 93,  94), Name = "Spell resistance (19)",       BaseAlterationModifier = 5 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = null,                   Medium = null,                   Major = new Interval( 95,  99), Name = "Energy resistance, greater",  BasePriceModifier = 66000 },
                new ArmorAndShieldSpecialAbilitiesTableLine { Minor = new Interval(100, 100), Medium = new Interval(100, 100), Major = new Interval(100, 100), Modify = RollArmorAbilityTwice },
            };
        }

        public override MagicArmorAndShield Create(Enums.ItemQuality quality)
        {
            //1. Roll pour avoir l'alteration
            AbstractArmorAndShieldsTableLine secondRoll;
            do
            {
                int alteration = MagicItemCreation.Instance.Dices.d100();

                secondRoll = ArmorCreation.ArmorAndShieldsTable.GetLineFromDice(alteration, quality);
            } while (secondRoll.GetType() != typeof(ArmorTableLine)
                    && secondRoll.GetType() != typeof(ShieldTableLine)); //On reroll tant qu'on a pas trouvé une ligne qu'on peut utiliser en tant que deuxième roll (si Create existe c'est un cas spécial et donc on ne peut pas l'utiliser)

            MagicArmorAndShield baseArmorAndShield = new MagicArmorAndShield(quality);

            //On ne devrait pas avoir de cas speciaux au deuxieme roll
            baseArmorAndShield.AlterationBonus = secondRoll.AlterationBonus;
            baseArmorAndShield.Type = (secondRoll.GetType() == typeof(ArmorTableLine)) ? ItemType.Armor : ItemType.Shield;

            //2. Ajout de capa speciale
            //Roll sur la table des capa melee
            int capa = MagicItemCreation.Instance.Dices.d100();
            ArmorAndShieldSpecialAbilitiesTableLine ligne;

            if (baseArmorAndShield.Type == Enums.ItemType.Armor)
                ligne = ArmorSpecialAbilitiesTable.GetLineFromDice(capa, quality);
            else 
                ligne = ShieldSpecialAbilitiesTable.GetLineFromDice(capa, quality);

            if (ligne.Modify != null) //Cas speciaux on appelle la fonction pour modifier
                ligne.Modify(baseArmorAndShield);
            else //Sinon on modifie a la main
            {
                baseArmorAndShield.Abilities = new List<String> { ligne.Name };
                baseArmorAndShield.BasePriceModifier = ligne.BasePriceModifier;
                baseArmorAndShield.BaseAlterationModifier = ligne.BaseAlterationModifier;
            }

            //3. On trouve le prix
            baseArmorAndShield.Price = ArmorCreation.ArmorAndShieldsTable.GetLineFromAlterationBonus(baseArmorAndShield.AlterationBonus + baseArmorAndShield.BaseAlterationModifier).Price;
            baseArmorAndShield.Price += baseArmorAndShield.BasePriceModifier;

            return baseArmorAndShield;
        }

        private static void RollShieldAbilityTwice(MagicArmorAndShield baseArmorAndShield)
        {
            int abilityRoll = MagicItemCreation.Instance.Dices.d100();

            ArmorAndShieldSpecialAbilitiesTableLine firstAbility = ShieldSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseArmorAndShield.Quality);

            if (baseArmorAndShield.Abilities == null)
                baseArmorAndShield.Abilities = new List<String>();

            baseArmorAndShield.Abilities.Add(firstAbility.Name);
            baseArmorAndShield.BasePriceModifier = firstAbility.BaseAlterationModifier;
            baseArmorAndShield.BaseAlterationModifier = firstAbility.BaseAlterationModifier;

            ArmorAndShieldSpecialAbilitiesTableLine secondAbility;
            do
            {
                abilityRoll = MagicItemCreation.Instance.Dices.d100();

                secondAbility = ShieldSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseArmorAndShield.Quality);

            } while (secondAbility.Modify != null //On reroll tant qu'on tombe sur un cas particulier
                     || (baseArmorAndShield.AlterationBonus + firstAbility.BaseAlterationModifier + secondAbility.BaseAlterationModifier) > 10); //ou encore que le total des alterations dépasse +10

            if (secondAbility == firstAbility)
                return;

            if (secondAbility.IsABetterVersionOf(firstAbility.Name))
            {
                baseArmorAndShield.Abilities.Remove(firstAbility.Name);
                baseArmorAndShield.Abilities.Add(secondAbility.Name);
                baseArmorAndShield.BasePriceModifier = secondAbility.BasePriceModifier;
                baseArmorAndShield.BaseAlterationModifier = secondAbility.BaseAlterationModifier;
            }
            else
            {
                baseArmorAndShield.Abilities.Add(secondAbility.Name);
                baseArmorAndShield.BasePriceModifier += secondAbility.BasePriceModifier;
                baseArmorAndShield.BaseAlterationModifier += secondAbility.BaseAlterationModifier;
            }
        }

        private static void RollArmorAbilityTwice(MagicArmorAndShield baseArmorAndShield)
        {
            int abilityRoll = MagicItemCreation.Instance.Dices.d100();

            ArmorAndShieldSpecialAbilitiesTableLine firstAbility = ArmorSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseArmorAndShield.Quality);

            if (baseArmorAndShield.Abilities == null)
                baseArmorAndShield.Abilities = new List<String>();

            baseArmorAndShield.Abilities.Add(firstAbility.Name);
            baseArmorAndShield.BasePriceModifier = firstAbility.BaseAlterationModifier;
            baseArmorAndShield.BaseAlterationModifier = firstAbility.BaseAlterationModifier;

            ArmorAndShieldSpecialAbilitiesTableLine secondAbility;
            do
            {
                abilityRoll = MagicItemCreation.Instance.Dices.d100();

                secondAbility = ArmorSpecialAbilitiesTable.GetLineFromDice(abilityRoll, baseArmorAndShield.Quality);

            } while (secondAbility.Modify != null //On reroll tant qu'on tombe sur un cas particulier
                     || (baseArmorAndShield.AlterationBonus + firstAbility.BaseAlterationModifier + secondAbility.BaseAlterationModifier) > 10); //ou encore que le total des alterations dépasse +10

            if (secondAbility == firstAbility)
                return;

            if (secondAbility.IsABetterVersionOf(firstAbility.Name))
            {
                baseArmorAndShield.Abilities.Remove(firstAbility.Name);
                baseArmorAndShield.Abilities.Add(secondAbility.Name);
                baseArmorAndShield.BasePriceModifier = secondAbility.BasePriceModifier;
                baseArmorAndShield.BaseAlterationModifier = secondAbility.BaseAlterationModifier;
            }
            else
            {
                baseArmorAndShield.Abilities.Add(secondAbility.Name);
                baseArmorAndShield.BasePriceModifier += secondAbility.BasePriceModifier;
                baseArmorAndShield.BaseAlterationModifier += secondAbility.BaseAlterationModifier;
            }
        }
    }
}
