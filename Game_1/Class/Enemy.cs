using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_1.Class
{
    public class Enemy : Character
    {
        public int GoldReward { get; set; }
        public Enemy()
        {
            Random r = new Random();
            this.HP = r.Next(30, 100);
            GoldReward = r.Next(50, 100);
            AttackPower = r.Next(10, 30);
            DefensePower = r.Next(10, 30);
        }
    }
}
