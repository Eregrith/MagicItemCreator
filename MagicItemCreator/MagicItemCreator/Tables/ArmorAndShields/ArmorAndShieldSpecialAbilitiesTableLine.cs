using MagicItemCreator.CustomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables.ArmorAndShields
{
    public class ArmorAndShieldSpecialAbilitiesTableLine : TableLine
    {
        //For normal abilities
        public String Name { get; set; }
        public int BasePriceModifier { get; set; }
        public int BaseAlterationModifier { get; set; }

        //For special case(s)
        public delegate void ModificationFuction(MagicArmorAndShield baseArmorAndShield);
        public ModificationFuction Modify { get; set; }

        public Boolean IsABetterVersionOf(string other)
        {
            switch (this.Name)
            {
                case "Shadow, improved":
                    return (other == "Shadow");

                case "Slick, improved":
                    return (other == "Slick");

                case "Shadow, greater":
                    return (other == "Shadow") || (other == "Shadow, improved");

                case "Slick, greater":
                    return (other == "Slick") || (other == "Slick, improved");

                case "Fortification, moderate":
                    return (other == "Fortification, light");

                case "Fortification, heavy":
                    return (other == "Fortification, light") || (other == "Fortification, medium");

                case "Energy resistance, improved":
                    return (other == "Energy resistance");

                case "Energy resistance, greater":
                    return (other == "Energy resistance, improved") || (other == "Energy resistance");

                case "Spell resistance (15)":
                    return (other == "Spell resistance (13)");

                case "Spell resistance (17)":
                    return (other == "Spell resistance (15)") || (other == "Spell resistance (17)");

                case "Spell resistance (19)":
                    return (other == "Spell resistance (15)") || (other == "Spell resistance (17)") || (other == "Spell resistance (19)");

                default:
                    return false;
            }
        }
    }
}
