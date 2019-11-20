using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCalculator.Models
{
    public class Person
    {
        public int Age { get; set; }
        public int Candies { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public override string ToString()
        {
            return $"{Firstname} ({Age} år): -> {Candies} godisar";
        }
    }
}
