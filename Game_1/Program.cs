using Game_1.Class;
using Game_1.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            while (player.HP > 0)
            {
                Enemy enemy = new Enemy();
                string scelta = string.Empty;
                while (true)
                {
                    GamePlay.PrintAttributes(player, enemy);
                    Console.WriteLine("Premi un tasto per attaccare!");
                    Console.ReadKey();
                    Console.WriteLine("Player attacca!");
                    GamePlay.Attack(player, enemy);

                    if (enemy.HP < 1)
                        break;

                    Console.WriteLine("Enemy attacca!");
                    Console.WriteLine("Vuoi provare a scappare?\n1 - si\n2 - no");
                    scelta = Console.ReadLine();

                    if ((scelta == "1" && !GamePlay.TryToRun()) || scelta == "2")  
                        GamePlay.Attack(enemy, player);

                    if (player.HP < 1)
                        break;

                    Console.WriteLine("Premi un tasto per continuare");
                    Console.ReadKey();
                }
                if (player.HP > 0)
                {
                    GamePlay.Win(player, enemy);
                    Console.WriteLine("Premi un tasto per continuare");
                    Console.ReadKey();
                }
            }
            GamePlay.Lose(player);
            Console.ReadKey();
        }
    }
}
