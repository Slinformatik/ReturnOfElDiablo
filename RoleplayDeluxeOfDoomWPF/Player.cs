using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayDeluxeOfDoomWPF
{
    class Player
    { 
        public string Name { get;}
        public int HP { get; set; }
        public int Max { get; }
        public List<Attack> Attacks { get; }

        public Player(string name, int hP, List<Attack> attacks)
        {
            Name = name;
            Max = hP;
            HP = hP;
            Attacks = attacks;
        }

    }
}
