using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            //Processing a file
            var players = ProcessFile("player.csv");
            var query = players.OrderBy(p => p.Debut);
            foreach (var player in query)
            {
                Console.WriteLine($" {player.Name}\t{player.Debut}");
            }
        }
        
        private static List<Player> ProcessFile(string path)
        {
            
            var query = from line in File.ReadAllLines(path).Skip(1)
                        where line.Length > 1
                        select Player.ParseFromCsv(line);

                                return query.ToList();
            
        }

        
    }
}
