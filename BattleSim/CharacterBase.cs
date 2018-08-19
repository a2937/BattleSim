using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BattleSim
{
    public class CharacterBase
    {
        private string characterName = "";
        private int level = 0;
        private int xp = 0;
        private int gold = 0;
        private int currentHP = 0;
        private int maxHP = 0;
        private int currentMP = 0;
        private int maxMP = 0;
        private int attack = 0;
        private int defense = 0;
        private int agility = 0;
        private int magicalMight = 0;
        private int magicalMend = 0;
        private int evade = 0;
        private int magicalEvade = 0;
        private int critRate = 0;
        private int physicalRes = 0;
        private int mentalRes = 0;
        private int deathRes = 0;
        private int fireRes = 0;
        private int iceRes = 0;
        private int windRes = 0;
        private int lightningRes = 0;
        private CharacterOccupation characterOccupation = null; 

        public CharacterBase()
        {
        }

        public string CharacterName
        {
            get
            {
                return characterName;
            }
            set
            {
                if(value.Length > 0)
                {
                    characterName = value;
                }
            }
        }

        public CharacterOccupation CharacterOccupation
        {
            get
            {
                return characterOccupation;
            }
            set
            {
                if(value != null)
                {
                    characterOccupation = value;
                }
            }
        }
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                if(value >= 0)
                {
                    level = value; 
                }
            }
        }

        public int XP
        {
            get
            {
                return xp;
            }
            set
            {
                if(value >= 0)
                {
                    xp = value;
                }
            }
        }

        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                if(value >= 0)
                {
                    gold = value;
                }
            }
        }

        public int CurrentHP
        {
            get
            {
                return currentHP;
            }
            set
            {
                if (value >= 0 && value <= MaxHP)
                {
                    currentHP = value;
                }
                else
                {
                    currentHP = 0;
                }
            }
        }

        public int MaxHP
        {
            get
            {
                return maxHP;
            }
            set
            {
                if(value >= 0)
                {
                    maxHP = value;
                }
            }
        }

        public int CurrentMP
        {
            get
            {
                return currentMP;
            }
            set
            {
                if (value >= 0 && value <= MaxMP)
                {
                    currentMP = value;
                }
                else
                {
                    currentMP = 0;
                }
            }
        }

        public int MaxMP
        {
            get
            {
                return maxMP;
            }
            set
            {
                if (value >= 0)
                {
                    maxMP = value;
                }
            }
        }

        public int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                if(value >= 0)
                {
                    attack = value; 
                }
            }
        }

        public int Defense
        {
            get
            {
                return defense;
            }
            set
            {
                if(value >= 0)
                {
                    defense = value;
                }
            }
        }

        public int Agility
        {
            get
            {
                return agility;
            }
            set
            {
                if (value >= 0)
                {
                    agility = value;
                }
            }
        }

        public int MagicalMight
        {
            get
            {
                return magicalMight;
            }
            set
            {
                if(value >= 0)
                {
                    magicalMight = value;
                }
            }
        }

        public int MagicalMend
        {
            get
            {
                return magicalMend;
            }
            set
            {
                if(value >= 0)
                {
                    magicalMend = value;
                }
            }
        }

        public int Evade
        {
            get
            {
                return evade;
            }
            set
            {
                if(value >= 0)
                {
                    evade = value;
                }
            }
        }

        public int MagicalEvade
        {
            get
            {
                return magicalEvade;
            }
            set
            {
                if(value >= 0)
                {
                    magicalEvade = value;
                }
            }
        }
        
        public int CritRate
        {
            get
            {
                return critRate;
            }
            set
            {
                if(value >= 0)
                {
                    critRate = value;
                }
            }
        }

        public int PhysicalResistance
        {
            get
            {
                return physicalRes;
            }
            set
            {
                if(value >= 0)
                {
                    physicalRes = value; 
                }
            }
        }

        public int MentalResistance
        {
            get
            {
                return mentalRes;
            }
            set
            {
                if(value >= 0)
                {
                    mentalRes = value; 
                }
            }
        }

        public int DeathResistance
        {
            get
            {
                return deathRes;
            }
            set
            {
                if(value >= 0)
                {
                    deathRes = value;
                }
            }
        }

        public int FireResistance
        {
            get
            {
                return fireRes;
            }
            set
            {
                if(value >= 0)
                {
                    fireRes = value;
                }
            }
        }

        public int IceResistance
        {
            get
            {
                return iceRes;
            }
            set
            {
                if(value >= 0)
                {
                    iceRes = value;
                }
            }
        }

        public int WindResistance
        {
            get
            {
                return windRes;
            }
            set
            {
                if(value >= 0)
                {
                    windRes = value;
                }
            }
        }

        public int LightningResistance
        {
            get
            {
                return lightningRes;
            }
            set
            {
                if(value >= 0)
                {
                    lightningRes = value; 
                }
            }
        }


        

        public void Save()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(this.Serialize());
            if(characterName == "")
            {
                xdoc.Save("myfilename" + ".xml");
            }
           else
            {
                xdoc.Save(characterName + ".xml"); 
            }
        }

        public new String ToString()
        {
            return CharacterName;
        }

        public static CharacterBase Load(string CharacterName)
        {
            if(CharacterName == "")
            {
                return ("myfilename.xml").DeserializeXMLFileToObject<CharacterBase>();
            }
           return (CharacterName + ".xml").DeserializeXMLFileToObject<CharacterBase>(); 
        }
    }
}
