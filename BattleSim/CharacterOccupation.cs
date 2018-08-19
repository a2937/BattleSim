using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim
{
    public class CharacterOccupation
    {
        private string occupationName = "";
        private int baseHp = 0;
        private int baseMp = 0;
        private int baseStr = 0;
        private int baseAgi = 0;
        private int baseRes = 0;
        private int baseInt = 0;
        private double hpGrowth = 0;
        private double mpGrowth = 0;
        private double strengthGrowth = 0;
        private double agiGrowth = 0;
        private double resGrowth = 0;
        private double intGrowth = 0;
        //private List<Spell> spells = new List<Spell>(20);

        public string OccupationName
        {
            get
            {
                return occupationName;
            }
            set
            {
                if (value.Length >= 0)
                {
                    occupationName = value;
                }
            }
        }

        public int BaseHp
        {
            get
            {
                return baseHp; 
            }
            set
            {
                if (baseHp == 0 && value >= 0)
                {
                    baseHp = value; 
                }
            }
        }

        public int BaseMp
        {
            get
            {
                return baseMp;
            }
            set
            {
                if (baseMp == 0 && value >= 0)
                {
                    baseMp = value;
                }
            }
        }

        public int BaseStrength
        {
            get
            {
                return baseStr;
            }
            set
            {
                if (baseStr == 0 && value >= 0)
                {
                    baseStr = value;
                }
            }
        }

        public int BaseAgility
        {
            get
            {
                return baseAgi;
            }
            set
            {
                if (baseAgi == 0 && value >= 0)
                {
                    baseAgi = value;
                }
            }
        }

        public int BaseResistance
        {
            get
            {
                return baseRes;
            }
            set
            {
                if (baseRes == 0 && value >= 0)
                {
                    baseRes = value;
                }
            }
        }

        public int BaseIntelligence
        {
            get
            {
                return baseInt;
            }
            set
            {
                if (baseInt == 0 && value >= 0)
                {
                    baseInt = value;
                }
            }
        }

        public double HpGrowth
        {
            get
            {
                return hpGrowth;
            }
            set
            {
                if (value >= 0)
                {
                    hpGrowth = value;
                    BaseHp = (int)((hpGrowth * 2) - 1 + 10);
                }
            }
        }

        public double MpGrowth
        {
            get
            {
                return mpGrowth;
            }
            set
            {
                if (value >= 0)
                {
                    mpGrowth = value;
                    BaseMp = (int)((mpGrowth * 2) - 1);
                }
            }
        }

        public double StrengthGrowth
        {
            get
            {
                return strengthGrowth;
            }
            set
            {
                if (value >= 0)
                {
                    strengthGrowth = value;
                    BaseStrength = (int)((strengthGrowth * 2) - 1);
                }
            }
        }

        public double AgilityGrowth
        {
            get
            {
                return agiGrowth;
            }
            set
            {
                if (value >= 0)
                {
                    agiGrowth = value;
                    BaseAgility = (int)((agiGrowth * 2) - 1);
                }
            }
        }

        public double ResistanceGrowth
        {
            get
            {
                return resGrowth;
            }
            set
            {
                if(value >= 0)
                {
                    resGrowth = value;
                    BaseResistance = (int)((resGrowth * 2) - 1);
                }
            }
        }

        public double IntelligenceGrowth
        {
            get
            {
                return intGrowth; 
            }
            set
            {
                if(value >= 0)
                {
                    intGrowth = value; 
                    BaseIntelligence = (int)(intGrowth * 2) - 1;
                }
            }
        }

        public new string ToString()
        {
            return OccupationName;
        }
    }
}
