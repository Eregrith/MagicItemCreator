using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.Enums
{
    //Type d'objet précis : Epee longue ? bouclier ?
    public enum ItemType
    {
        //Types generiques, avant les types
        Armor,
        Shield,
        Weapon,
        //à completer ...
    }

    public enum ItemQuality
    {
        Minor,
        Medium,
        Major,
    }

    public enum Range
    {
        Melee,
        Ranged
    }
}
