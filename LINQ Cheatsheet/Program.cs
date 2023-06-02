using System;

namespace LINQ_Cheatsheet
{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Any
            int[] numbers = { 1, 2, 3, 4, 5 };
            bool anyNumbers = numbers.Any();
            // Output: True

            int[] evenNumbers = { 1, 3, 5, 7, 9 };
            bool anyEvenNumbers = evenNumbers.Any(n => n % 2 == 0);
            // Output: False

            List<string> nameList = new() { "Alice", "Bob", "Charlie" };
            bool anyNames = nameList.Any();
            // Output: True

            List<string> namesStartingWithB = new() { "Bob", "Bella", "Ben" };
            bool anyNamesStartingWithB = namesStartingWithB.Any(name => name.StartsWith("B"));
            // Output: True

            List<Person> people = new()
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 30 },
                new Person { Name = "Charlie", Age = 20 }
            };
            bool anyAdult = people.Any(p => p.Age >= 18);
            // Output: True
            #endregion
        }
    }
}