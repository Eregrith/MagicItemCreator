using MagicItemCreator.Enums;
using MagicItemCreator.Tables;
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

        public static WeaponTableLine GetLineFromAlterationBonus(this List<WeaponTableLine> table, int alterationBonus)
        {
            return table.Single(ligne => ligne.AlterationBonus == alterationBonus);
        }
    }
}
