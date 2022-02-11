using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThetaWeather
{
    internal class Main
    {
        public Main()
        {
            try
            {
                var fileName = "weather.txt";
                var lines = File.ReadAllLines(fileName).ToList();

                //remove the preamble
                lines.RemoveRange(0, 8);

                //remove the final <pre> tag
                lines.RemoveAt(lines.Count - 1);

                //remove the monthly average data
                lines.RemoveAt(lines.Count - 1);


                var days = new List<DayModel>();
                foreach (string line in lines)
                {
                    var lineProps = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    //some temperatures have stars to indicate they are monthly max or min - remove this info since we don't need it
                    lineProps[1] = lineProps[1].Replace("*", "");
                    lineProps[2] = lineProps[2].Replace("*", "");
                    days.Add(new DayModel(int.Parse(lineProps[0]), int.Parse(lineProps[1]), int.Parse(lineProps[2])));
                }

                days = days.OrderBy(day => day.TempRange).ToList();
                var lowest = days.FirstOrDefault();

                Console.WriteLine($"The day with the lowest range of temperature is day {lowest.DayNumber} with a temperature range of {lowest.TempRange} degrees.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}
