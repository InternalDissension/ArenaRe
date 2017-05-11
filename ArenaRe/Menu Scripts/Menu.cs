using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    abstract class Menu
    {
        /// <summary>
        /// Displays the menu and its options
        /// </summary>
        protected abstract int displayMenu();

        /// <summary>
        /// Processes the chosen option on the menu
        /// </summary>
        protected abstract int processMenuChoice(int choice);
    }
}
