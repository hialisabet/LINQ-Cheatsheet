using System;
using System.Linq;

namespace LINQ_Cheatsheet
{

    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Any
            // Example 1: LINQ Any
            int[] numbersAny = { 1, 2, 3, 4, 5 };
            bool anyNumbers = numbersAny.Any();
            // Output: True

            // Example 2: LINQ Any with Predicate
            int[] evenNumbersAny = { 1, 3, 5, 7, 9 };
            bool anyEvenNumbers = evenNumbersAny.Any(n => n % 2 == 0);
            // Output: False

            // Example 3: LINQ Any on List
            List<string> nameListAny = new() { "Alice", "Bob", "Charlie" };
            bool anyNames = nameListAny.Any();
            // Output: True

            // Example 4: LINQ Any with Predicate on List
            List<string> namesStartingWithBAny = new() { "Bob", "Bella", "Ben" };
            bool anyNamesStartingWithB = namesStartingWithBAny.Any(name => name.StartsWith("B"));
            // Output: True

            // Example 5: LINQ Any on Empty List
            List<int> emptyListAny = new();
            bool anyEmptyList = emptyListAny.Any();
            // Output: False
            #endregion

            #region All
            // Example 1: LINQ All
            int[] numbersAll = { 1, 2, 3, 4, 5 };
            bool allNumbers = numbersAll.All(n => n > 0);
            // Output: True

            // Example 2: LINQ All on Empty Array
            int[] emptyArrayAll = Array.Empty<int>();
            bool allEmptyArray = emptyArrayAll.All(n => true);
            // Output: True

            // Example 3: LINQ All with Predicate
            string[] namesAll = { "Alice", "Bob", "Charlie" };
            bool allNamesStartWithA = namesAll.All(name => name.StartsWith("A"));
            // Output: False

            // Example 4: LINQ All on List
            List<int> numberListAll = new() { 2, 4, 6, 8, 10 };
            bool allEvenNumbers = numberListAll.All(n => n % 2 == 0);
            // Output: True

            // Example 5: LINQ All with Predicate on List
            List<string> namesAllCaps = new() { "ALICE", "BOB", "CHARLIE" };
            bool allNamesInUpperCase = namesAllCaps.All(name => name.All(char.IsUpper));
            // Output: True

            // Example 6: LINQ All on Empty List
            List<int> emptyListAll = new();
            bool allEmptyList = emptyListAll.All(n => true);
            // Output: True

            // Example 7: LINQ All check not null
            List<Person> persons = new()
            {
                new Person { Name = "Alice" },
                new Person { Name = "Bob" },
                new Person { Name = "Charlie" },
                new Person { Name = null },
                new Person { Name = "Eve" }
            };
            bool allNamesNotNull = persons.All(person => person.Name != null);
            // Output: False

            #endregion

            #region Count
            // Example 1: Count all numbers in the array
            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int countNumbers1 = numbers1.Count();
            // Output: 5

            // Example 2: Count all names in the array
            string[] names = { "Alice", "Bob", "Charlie" };
            int countNames = names.Count();
            // Output: 3

            // Example 3: Count elements in an empty list
            List<int> emptyList = new();
            int countEmptyList = emptyList.Count();
            // Output: 0

            // Example 4: Count names starting with 'B' in a list
            List<string> namesStartingWithB = new() { "Bob", "Bella", "Ben" };
            int countNamesStartingWithB = namesStartingWithB.Count(name => name.StartsWith("B"));
            // Output: 2

            // Example 5: Count numbers greater than three in a list
            List<int> numbersGreaterThanThree = new() { 4, 5, 6, 7, 8 };
            int countNumbersGreaterThanThree = numbersGreaterThanThree.Count(n => n > 3);
            // Output: 4

            // Example 6: Count non-null names in a list
            List<string> namesNull = new() { "Alice", null, "Bob", null, "Charlie" };
            int countNonNullNames = namesNull.Count(name => name != null);
            // Output: 3
            #endregion

            #region Contains

            #endregion
        }
    }
}