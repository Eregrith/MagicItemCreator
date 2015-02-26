﻿using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables.Weapons
{
    public class WeaponSpecialAbilitiesTableLine : TableLine
    {
        //For normal abilities
        public String Name { get; set; }
        public int BaseAlterationModifier { get; set; }

        //For special case(s)
        public delegate void ModificationFuction(MagicWeapon baseWeapon);
        public ModificationFuction Modify { get; set; }
    }
}
