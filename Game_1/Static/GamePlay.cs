using Game_1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_1.Static
{
    public static class GamePlay
    {
        public static void Attack(Character attack, Character defense)
        {
            Random r = new Random();
            if (r.Next(0, 100) <= 70)
            {
                Console.WriteLine("\nDifesa riuscita!\n");
                if(defense.DefensePower < attack.AttackPower)
                {
                    defense.HP -= (attack.AttackPower - defense.DefensePower);
                    Console.WriteLine("Punti vita sottratti: " + (attack.AttackPower - defense.DefensePower) + "\nVita rimasta: " + defense.HP);
                }
                else
                {
                    if (r.Next(0, 2) == 0)
                    {
                        Console.WriteLine("\nDanno collaterale!\n");
                        defense.HP -= (defense.DefensePower - attack.AttackPower);
                        Console.WriteLine("Punti vita sottratti: " + (defense.DefensePower - attack.AttackPower) + "\nVita rimasta: " + defense.HP);
                    }
                    else
                        Console.WriteLine("Nessun attacco subito.\nVita rimasta: " + defense.HP + "\n");
                }
            }
            else
            {
                Console.WriteLine("\nDifesa NON riuscita!\n");
                defense.HP -= attack.AttackPower;
                Console.WriteLine("Punti vita sottratti: " + attack.AttackPower + "\nVita rimasta: " + defense.HP);
            }
        }
        public static bool TryToRun()
        {
            Random r = new Random();
            if (r.Next(0, 100) <= 35)
            {
                Console.WriteLine("Sei riuscito a scappare!");
                Console.WriteLine("Attacco non riuscito!");
                return true;
            }
            else
            {
                Console.WriteLine("NON sei riuscito a scappare!");
                return false;
            }
        }
        public static void Win(Player player, Enemy enemy)
        {
            player.Gold += enemy.GoldReward;
            player.WonPlay++;
            Console.Clear();
            Console.WriteLine("Hai vinto lo scontro!\nGuadagni: " + enemy.GoldReward + " oro");
            Console.WriteLine("Vittorie totali: " + player.WonPlay + "\noro totale: " + player.Gold);
        }
        public static void Lose(Player player)
        {
            Random r = new Random();
            int goldLose = r.Next(2, 6);
            player.Gold -= goldLose;
            Console.Clear();
            Console.WriteLine("Sei morto... :(\nPerdi: " + goldLose + " oro");
            Console.WriteLine("Vittorie totali: " + player.WonPlay + "\noro totale: " + player.Gold);
        }
        public static void PrintAttributes(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine(" - - - PLAYER - - - ");
            Console.WriteLine("Vita: " + player.HP);
            Console.WriteLine("Attacco: " + player.AttackPower);
            Console.WriteLine("Difesa: " + player.DefensePower);
            Console.WriteLine(" - - - ENEMY - - - ");
            Console.WriteLine("Vita: " + enemy.HP);
            Console.WriteLine("Attacco: " + enemy.AttackPower);
            Console.WriteLine("Difesa: " + enemy.DefensePower + "\n\n");
        }
    }
}
