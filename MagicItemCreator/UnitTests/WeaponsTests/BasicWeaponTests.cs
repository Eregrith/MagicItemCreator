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
    }
}
