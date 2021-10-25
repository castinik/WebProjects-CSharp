using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_1.Class
{
    public class Player : Character
    {
        public int Gold { get; set; }
        public int WonPlay { get; set; }
        public Player()
        {
            Random r = new Random();
            this.HP = r.Next(50, 100);
            AttackPower = r.Next(15, 30);
            DefensePower = r.Next(15, 30);
        }
    }
}
