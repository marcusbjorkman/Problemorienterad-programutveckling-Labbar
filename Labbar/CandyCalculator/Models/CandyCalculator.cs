using CandyCalculator.Enums;

using System.Collections.Generic;
using System.Linq;

namespace CandyCalculator.Models
{
    public class CandyDivider
    {
        public int NumberOfCandies { get; set; }

        private readonly List<Person> people = new List<Person>();

        public void AddPerson(Person person)
        {
            people.Add(person);
        }

        public void DivideCandy(DivideCandyMethod method = DivideCandyMethod.ByOrder)
        {
            int candiesPerPerson = NumberOfCandies / people.Count;
            int rest = NumberOfCandies % people.Count;

            foreach (var p in people)
            {
                p.Candies = candiesPerPerson;
            }

            IEnumerable<Person> toGiveExtraCandies = null;
            if (method == DivideCandyMethod.ByOrder)
            {
                toGiveExtraCandies = people.Take(rest);
            }
            else if (method == DivideCandyMethod.ByAge)
            {
                toGiveExtraCandies = people.OrderBy(o => o.Age).Take(rest);
            }
            else
            {
                toGiveExtraCandies = people.OrderBy(o => o.Firstname).Take(rest);
            }

            foreach (var p in toGiveExtraCandies)
            {
                p.Candies++;
            }
        }

        public List<Person> GetPeople()
        {
            return new List<Person>(people);
        }
    }
}
