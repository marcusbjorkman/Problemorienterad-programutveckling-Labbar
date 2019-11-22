using System;
using System.Runtime.Serialization;

namespace CandyCalculator.Models
{
    [Serializable]
    public class Person : ISerializable
    {
        public int Age { get; set; }
        public int Candies { get; set; }
        public string Firstname { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Age), Age);
            info.AddValue(nameof(Firstname), Firstname);
        }
        public Person(SerializationInfo info, StreamingContext context)
        {
            Age = info.GetInt32(nameof(Age));
            Firstname = info.GetString(nameof(Firstname));
        }

        public Person()
        {

        }

        public override string ToString()
        {
            return $"{Firstname} ({Age} år): -> {Candies} godisar";
        }
    }
}
