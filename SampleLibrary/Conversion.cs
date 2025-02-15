using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class Conversion
    {
        public decimal ConvertTemperature(decimal temperature, string from = "C", string to = "F")
        {
            from = from.Substring(0, 1).ToUpper();
            to = to.Substring(0, 1).ToUpper();
            
            if (!"CFK".Contains(from) || !"CFK".Contains(to))
            {
                throw new ArgumentException("Invalid temperature scale. Use 'C', 'F', or 'K'.");
            }

            if (from == to)
            {
                return temperature;
            }

            switch (from)
            {
                case "C":
                    return to == "F" ? temperature * 9 / 5 + 32 : temperature + 273.15m;
                case "F":
                    return to == "C" ? (temperature - 32) * 5 / 9 : (temperature + 459.67m) * 5 / 9;
                case "K":
                    return to == "C" ? temperature - 273.15m : temperature * 9 / 5 - 459.67m;
                default:
                    throw new ArgumentException("Invalid temperature scale. Use 'C', 'F', or 'K'.");
            }
        }
    }
}
