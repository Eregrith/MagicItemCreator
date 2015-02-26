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
    }
}
