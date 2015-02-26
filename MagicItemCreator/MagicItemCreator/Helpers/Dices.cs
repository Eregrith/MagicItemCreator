using MagicItemCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Helpers
{
    public class Dices : IDices
    {
        #region random init

        private static Random _r;
        private static Random DiceGenerator
        {
            get
            {
                if (_r == null)
                    _r = new Random();
                return _r;
            }
        }
        #endregion

        public int d100()
        {
            return DiceGenerator.Next(1, 101); //entre 1 et 100, le max est non-inclus
        }
    }
}
