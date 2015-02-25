using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.CustomTypes
{
    public class MagicWeapon : MagicItem
    {
        public int AlterationBonus { get; set; }
        public int BasePriceModifier { get; set; }

        public List<String> Abilities { get; set; }

        public Range Range { get; set; }

        public MagicWeapon(ItemQuality quality)
            : base(quality)
        { }

        public override string ToString()
        {
            String desc = String.Format("[{4}] {0}{5} magic {6} {1} +{2} costing {3} po", Name, Type.ToString(), AlterationBonus, Price, Quality, Name != null ? "," : "", Range);

            if (Abilities != null)
            {
                desc += " and with " + ((Abilities.Count > 1) ?  "these" : "this") + " ability:";
                foreach (String ability in Abilities)
                {
                    desc += Environment.NewLine + String.Format("       - {0}", ability);
                }
            }

            return desc;
        }
    }
}
