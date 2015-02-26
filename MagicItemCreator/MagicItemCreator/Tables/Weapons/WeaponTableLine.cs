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

            item.Range = MagicItemCreation.Instance.ChosenRange;
            item.AlterationBonus = this.AlterationBonus;
            item.Price = this.Price;
            item.Range = MagicItemCreation.Instance.ChosenRange;
            item.Type = ItemType.Weapon;

            return item;
        }
    }
}
