using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fanOpener
{
    public class Duration
    {
        public static Duration shortF { get; set; }
        public static Duration mediumF { get; set; }
        public static Duration longF { get; set; }

        public string Name { get; set; }
        public int Value { get; set; }

        public Duration(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public static IEnumerable<Duration> List()
        {
            // alternately, use a dictionary keyed by value
            return new[] { shortF, mediumF, longF };
        }

        public static Duration FromString(string durationString)
        {
            return List().Single(r => String.Equals(r.Name, durationString, StringComparison.OrdinalIgnoreCase));
        }

        public static Duration FromValue(int value)
        {
            return List().Single(r => r.Value == value);
        }
    }
}
