using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim
{
    public abstract class Item
    {
        private string itemName;

        public String ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                if (value.Length > 0)
                {
                    itemName = value;
                }
            }
        }
    }
}
