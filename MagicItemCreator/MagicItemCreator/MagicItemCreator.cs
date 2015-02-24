using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Helpers;
using MagicItemCreator.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagicItemCreator.Helpers;
using MagicItemCreator.Creators;

namespace MagicItemCreator
{
    public class MagicItemCreator
    {
        public List<MagicItemTableLine> MagicItemsTable { get; set; }
        public List<WeaponTableLine> WeaponsTable { get; set; }

        public MagicItemCreator()
        {
            MagicItemsTable = new List<MagicItemTableLine>
            {
                new MagicItemTableLine { Minor = new Interval(1, 4), Medium = new Interval(1, 10), Major = new Interval(1, 10), Item = ItemType.ArmorAndShield },
                new MagicItemTableLine { Minor = new Interval(5, 9), Medium = new Interval(11, 20), Major = new Interval(11, 20), Item = ItemType.Weapon },
                //à compléter ...
            };

            WeaponsTable = new List<WeaponTableLine>
            {
                new WeaponTableLine { Minor = new Interval(1, 70), Medium = new Interval(1,10), Major = null, Create = WeaponCreation.CreatePlusOne },
                new WeaponTableLine { Minor = new Interval(71, 85), Medium = new Interval(11,29), Major = null, Create = WeaponCreation.CreatePlusTwo },
            };
        }

        public MagicItem CreateItem(ItemType itemType, ItemQuality quality)
        {
            MagicItem item;

            int de = Dices.d100();

            MagicItemTableLine ligne = (MagicItemTableLine)MagicItemsTable.GetLineFromDice(de, quality);

            item = CreateTyped(ligne.Item, quality);

            return item;
        }

        public MagicItem CreateTyped(ItemType itemType, ItemQuality quality)
        {
            MagicItem item;

            int de = Dices.d100();

            WeaponTableLine ligne = (WeaponTableLine)WeaponsTable.GetLineFromDice(de, quality);

            item = ligne.Create(quality);

            return item;
        }
    }
}
