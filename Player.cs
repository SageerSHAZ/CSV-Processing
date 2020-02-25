using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class Player
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Debut { get; set; }
        public int Matches { get; set; }
        public double Average { get; set; }


        //this is parsing of CSV file into Car object
        internal static Player ParseFromCsv(string line)
        {
            var columns = line.Split(',');
            return new Player
            {
                Name = columns[0],
                Country = columns[1],
                Debut = int.Parse(columns[2]),
                Matches = int.Parse(columns[3]),
                Average = double.Parse(columns[4])

            };
        }
    }
}
