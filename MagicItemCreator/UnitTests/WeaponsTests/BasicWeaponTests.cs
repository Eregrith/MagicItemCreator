using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.MockObjects;
using MagicItemCreator.Creators;
using MagicItemCreator.Enums;
using MagicItemCreator.CustomTypes;
using FluentAssertions;
using System.Collections.Generic;

namespace UnitTests.WeaponsTests
{
    [TestClass]
    public class BasicWeaponTests
    {
        //Tests de jet d'arme précis
        [TestMethod]
        public void CheckMinorWeapon()
        {
            //On prepare les jets :
            // 7 -> Weapon
            // 73 -> arme +2 à 8000po
            MockDices dices = new MockDices(new List<int> { 7, 73 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Minor);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Minor);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(8000);
            weapon.AlterationBonus.Should().Be(2);
            weapon.Abilities.Should().BeNull();
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void CheckMediumWeapon()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 37 -> arme +3 à 18000po
            MockDices dices = new MockDices(new List<int> { 13, 37 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Medium);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Medium);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(18000);
            weapon.AlterationBonus.Should().Be(3);
            weapon.Abilities.Should().BeNull();
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void CheckMajorWeapon()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 43 -> arme +5 à 50000po
            MockDices dices = new MockDices(new List<int> { 13, 43 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Major);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Major);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(50000);
            weapon.AlterationBonus.Should().Be(5);
            weapon.Abilities.Should().BeNull();
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void MinorWeaponWithOneSpecialAbility()
        {
            //On prepare les jets :
            //  7 -> Weapon
            // 93 -> Special ability
            // 78 -> Arme +2 qui coute 8000 po
            // 89 -> capa "Throwing" qui fait +1, donc arme +2 qui coute 18000
            MockDices dices = new MockDices(new List<int> { 7, 93, 78, 89 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Minor);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Minor);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(18000);
            weapon.AlterationBonus.Should().Be(2);
            weapon.Abilities.Should().NotBeNull();
            weapon.Abilities.Count.Should().Be(1);
            weapon.Abilities[0].Should().Be("Throwing");
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void MediumWeaponWithTwoSpecialAbilities()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 93 -> Special ability
            // 34 -> Arme +3 qui coute 18000 po
            // 98 -> double capas
            // 41 -> capa "Keen" qui fait +1
            // 68 -> capa "Vicious" qui fait +1, donc arme +3 qui coute 50000
            MockDices dices = new MockDices(new List<int> { 13, 93, 34, 98, 41, 68 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Medium);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Medium);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(50000);
            weapon.AlterationBonus.Should().Be(3);
            weapon.Abilities.Should().NotBeNull();
            weapon.Abilities.Count.Should().Be(2);
            weapon.Abilities[0].Should().Be("Keen");
            weapon.Abilities[1].Should().Be("Vicious");
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void SpecificMajorWeapon()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 55 -> Specific weapon
            // 83 -> Dwarven thrower qui coute 60312 po
            MockDices dices = new MockDices(new List<int> { 13, 55, 83 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Major);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Major);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(60312);
            weapon.Abilities.Should().BeNull();
            weapon.Name.Should().Be("Dwarven thrower");
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void SameAbilityIsRerolled()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 93 -> Special ability
            // 34 -> Arme +3 qui coute 18000 po
            // 98 -> double capas
            // 41 -> capa "Keen" qui fait +1
            // 41 -> capa "Keen" une deuxieme fois, normalement rerollé
            // 41 -> capa "Keen" une troisième fois, normalement rerollé
            // 41 -> capa "Keen" une quatrième fois, normalement rerollé
            // 41 -> capa "Keen" une cinquième fois, normalement rerollé
            // 68 -> capa "Vicious" qui fait +1, donc arme +3 qui coute 50000
            MockDices dices = new MockDices(new List<int> { 13, 93, 34, 98, 41, 41, 41, 41, 41, 68 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Medium);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Medium);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(50000);
            weapon.AlterationBonus.Should().Be(3);
            weapon.Abilities.Should().NotBeNull();
            weapon.Abilities.Count.Should().Be(2);
            weapon.Abilities[0].Should().Be("Keen");
            weapon.Abilities[1].Should().Be("Vicious");
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void IncompatibleAbilityIsRerolled()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 93 -> Special ability
            // 15 -> Arme +2 qui coute 8000 po
            // 98 -> double capas
            // 86 -> capa "Holy" qui fait +2
            // 92 -> capa "Unholy", incompatible normalement rerollé
            // 68 -> capa "Vicious" qui fait +1, donc arme +2 qui coute 50000
            MockDices dices = new MockDices(new List<int> { 13, 93, 15, 98, 86, 92, 68 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Medium);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Medium);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(50000);
            weapon.AlterationBonus.Should().Be(2);
            weapon.Abilities.Should().NotBeNull();
            weapon.Abilities.Count.Should().Be(2);
            weapon.Abilities[0].Should().Be("Holy");
            weapon.Abilities[1].Should().Be("Vicious");
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void AbilityGoingOverPlusTenAreRerolled()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 93 -> Special ability
            // 43 -> Arme +5 qui coute 50000 po
            // 98 -> double capas
            // 85 -> capa "Brilliant energy" qui fait +4
            // 57 -> capa "Icy burst" qui fait +2, normalement rerollé
            // 82 -> capa "Speed" qui fait +3, normalement rerollé
            // 26 -> capa "Throwing" qui fait +1, donc arme +5 qui coute 200000
            MockDices dices = new MockDices(new List<int> { 13, 93, 43, 98, 85, 57, 82, 26 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Major);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Major);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(200000);
            weapon.AlterationBonus.Should().Be(5);
            weapon.Abilities.Should().NotBeNull();
            weapon.Abilities.Count.Should().Be(2);
            weapon.Abilities[0].Should().Be("Brilliant energy");
            weapon.Abilities[1].Should().Be("Throwing");
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void PlusFiveWeaponGettingVorpalHasOnlyOneAbility()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 93 -> Special ability
            // 43 -> Arme +5 qui coute 50000 po
            // 98 -> double capas
            // 89 -> capa "Vorpal" qui fait +5
            //  2 -> capa "Bane" qui fait +1, jamais atteint, donc arme +5 qui coute 200000
            MockDices dices = new MockDices(new List<int> { 13, 93, 43, 98, 89, 2 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Major);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Major);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(200000);
            weapon.AlterationBonus.Should().Be(5);
            weapon.Abilities.Should().NotBeNull();
            weapon.Abilities.Count.Should().Be(1);
            weapon.Abilities[0].Should().Be("Vorpal");
            weapon.Range.Should().Be(chosenRange);
        }

        [TestMethod]
        public void AbilitiesCorrectlyAffectPriceAbovePlusFive()
        {
            //On prepare les jets :
            // 13 -> Weapon
            // 93 -> Special ability
            // 61 -> Arme +4 qui coute 32000 po
            // 98 -> double capas
            // 86 -> capa "Holy" qui fait +2
            // 68 -> capa "Vicious" qui fait +1, donc arme +2 qui coute 98000
            MockDices dices = new MockDices(new List<int> { 13, 93, 61, 98, 86, 68 });

            //Utilisation des dés pipés :P
            MagicItemCreation.Instantiate(dices);

            //Portee = melee
            Range chosenRange = Range.Melee;

            MagicItemCreation.Instance.ChosenRange = chosenRange;

            //Creation
            MagicItem item = MagicItemCreation.Instance.Create(ItemQuality.Medium);

            item.GetType().Should().Be(typeof(MagicWeapon));

            MagicWeapon weapon = item as MagicWeapon;

            weapon.Quality.Should().Be(ItemQuality.Medium);
            weapon.Type.Should().Be(ItemType.Weapon);
            weapon.Price.Should().Be(98000);
            weapon.AlterationBonus.Should().Be(4);
            weapon.Abilities.Should().NotBeNull();
            weapon.Abilities.Count.Should().Be(2);
            weapon.Abilities[0].Should().Be("Holy");
            weapon.Abilities[1].Should().Be("Vicious");
            weapon.Range.Should().Be(chosenRange);
        }
    }
}
