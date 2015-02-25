using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagicItemCreator;
using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;

namespace MagicItemCreator.Tables
{
    //Table: Random Magic Item Generation
    public class MagicItemTableLine : TableLine
    {
        public ItemType Item { get; set; }
        
        public delegate MagicItem CreateFunction(ItemQuality quality);
        public CreateFunction Create { get; set; }
    }
}
