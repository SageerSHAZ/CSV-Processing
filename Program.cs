using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");
            
            #region Projection using query syntax and Extension method syntax 
            var query =
               from car in cars
               join manufacturer in manufacturers 
              on car.Manufacturer equals manufacturer.Name
               orderby car.Combined descending, car.Name ascending
               select new
               {
                   manufacturer.Headquarters,
                   car.Name,
                   car.Combined
               };

            var query2 = cars.Join(manufacturers, c => c.Manufacturer, m => m.Name, (c, m) => new
            {
                m.Headquarters,
                c.Name,
                c.Combined
            })
            .OrderByDescending(c => c.Combined)
            .ThenBy(c => c.Name);
            
            
            foreach (var car in query2.Take(10))
                {
                    Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
                }
            #endregion
        }

        private static List<Car> ProcessCars(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                   File.ReadAllLines(path)
                       .Where(l => l.Length > 1)
                       .Select(l =>
                       {
                           var columns = l.Split(',');
                           return new Manufacturer
                           {
                               Name = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])
                           };
                       });
            return query.ToList();
        }
    }
}
