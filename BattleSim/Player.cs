using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim
{
    class Player : CharacterBase
    {
        private int renown = 0; 

        public int Renown
        {
            get
            {
                return renown;
            }
            set
            {
                if(value >= 0)
                {
                    renown = value; 
                }
            }
        }

        public void LevelUp()
        {
            Level = Level + 1; 
        }

        public new static Player Load(string CharacterName)
        {
            if (CharacterName == "")
            {
                return ("myfilename.xml").DeserializeXMLFileToObject<Player>();
            }
            return (CharacterName + ".xml").DeserializeXMLFileToObject<Player>();
        }
    }
}
