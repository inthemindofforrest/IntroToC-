using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProperties
{
    public class Player
    {
        public string name
        {
            get { return name; }
            set { name = (value.Length > 0) ? value : name; }//If the value is greator than 0}
        }
        public int FragCount;
        public int DeathCount;
        public int TotalDamage;

        public int Score { get { return (DeathCount - FragCount); } }
    }
}
