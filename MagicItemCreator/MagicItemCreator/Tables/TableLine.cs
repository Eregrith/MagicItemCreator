using MagicItemCreator.CustomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Tables
{
    //Classe de base pour toutes les lignes des tables : un minor un medium et un major
    //Toutes les classes qui héritent de TableLine (Par exemple public class MagicItemTableLine : TableLine)
    //auront ces propriétés
    public class TableLine
    {
        public Interval Minor { get; set; }
        public Interval Medium { get; set; }
        public Interval Major { get; set; }
    }
}
