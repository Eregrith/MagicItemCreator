using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Helpers;
using MagicItemCreator.Interfaces;
using MagicItemCreator.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Creators
{
    public class MagicItemCreation
    {
        public List<MagicItemTableLine> MagicItemsTable { get; set; }

        private MagicItemCreation()
        {
            InitMagicItemsTable();
            Dices = new Dices();
        }

        private static MagicItemCreation _instance;
        public static MagicItemCreation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MagicItemCreation();
                return _instance;
            }
        }

        public static void Instantiate(IDices dicesDependency)
        {
            _instance = new MagicItemCreation(dicesDependency);
        }

        //Type d'arme (utilisé si on cree une arme) : Melee ou distance
        public Range ChosenRange { get; set; }

        public IDices Dices { get; set; }

        public MagicItemCreation(IDices dices)
        {
            InitMagicItemsTable();
            Dices = dices;
        }

        private void InitMagicItemsTable()
        {
            MagicItemsTable = new List<MagicItemTableLine>
            {
                new MagicItemTableLine { Minor = new Interval( 1,   4), Medium = new Interval( 1,  10), Major = new Interval( 1,  10), Create = ArmorCreation.Create },
                new MagicItemTableLine { Minor = new Interval( 5,   9), Medium = new Interval(11,  20), Major = new Interval(11,  20), Create = WeaponCreation.Create },
                //à compléter ...
            };
        }

        public MagicItem Create(ItemQuality quality)
        {
            MagicItem item;

            int de = Dices.d100();

            MagicItemTableLine ligne = MagicItemsTable.GetLineFromDice(de, quality);

            item = ligne.Create(quality);

            return item;
        }
    }
}
