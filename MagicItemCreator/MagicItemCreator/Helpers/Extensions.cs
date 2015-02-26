using MagicItemCreator.Enums;
using MagicItemCreator.Tables;
using MagicItemCreator.Tables.ArmorAndShields;
using MagicItemCreator.Tables.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Helpers
{
    public static class Extensions
    {
        public static T GetLineFromDice<T>(this List<T> table, int dice, ItemQuality quality) where T : TableLine
        {
            return table.Single(ligne =>
                {
                    switch (quality)
                    {
                        case ItemQuality.Minor:
                            return (ligne.Minor != null && ligne.Minor.Inside(dice));
                        case ItemQuality.Medium:
                            return (ligne.Medium != null && ligne.Medium.Inside(dice));
                        case ItemQuality.Major:
                            return (ligne.Major != null && ligne.Major.Inside(dice));
                    }
                    return false;
                });
        }

        public static AbstractWeaponTableLine GetLineFromAlterationBonus(this List<AbstractWeaponTableLine> table, int alterationBonus)
        {
            return table.Single(ligne => ligne.AlterationBonus == alterationBonus);
        }

        public static AbstractArmorAndShieldsTableLine GetLineFromAlterationBonus(this List<AbstractArmorAndShieldsTableLine> table, int alterationBonus)
        {
            return table.First(ligne => ligne.AlterationBonus == alterationBonus); //First parce qu'il y a Armure ET bouclier dans la table donc 2 lignes pour chaque bonus entre +1 et +5, mais le prix est le même donc osef
        }
    }
}
