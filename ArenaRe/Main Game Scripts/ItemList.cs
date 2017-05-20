using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class ItemList
    {
        static internal Item shortSword;
        static internal Item longSword;
        static internal Item greatSword;
        static internal Item battleAxe;
        static internal Item steelAxe;
        static internal Item magicRing;
        static internal Item shield;

        static internal void initializeItems()
        {
            shortSword = new Item("Shortsword", 1, 0, 1, 0, 0, 2, 0, 0, 1, 100, 1, 1, new Effect[] { });
            longSword = new Item("Longsword", 3, 0, 2, 0, 0, 4, 0, 0, 1, 100, 1, 2, new Effect[] { });
            greatSword = new Item("Greatsword", 8, 0, 2, 0, 4, 6, 0, 1, 2, 795, 2, 3, new Effect[] { });
            battleAxe = new Item("Battleaxe", 5, 0, 1, 0, 0, 10, 0, 0, 2, 750, 2, 3, new Effect[] { });
            steelAxe = new Item("Axe of Mirth", 3, 0, 1, 0, 1, 3, 0, 0, 1, 275, 1, 2, new Effect[] { });
            magicRing = new Item("Juda's Ring", 0, 50, 0, 10, 0, 0, 0, 3, 0, 2500, 0, 0, new Effect[] { });
            shield = new Item("Shield", 0, 0, 0, 0, 0, 0, 0, 0, 1, 100, 1, 10, new Effect[] { });
        }
    }
}
