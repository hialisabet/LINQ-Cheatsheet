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
            #endregion
        }
    }
}