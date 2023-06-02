using System;
using System.Linq;

namespace LINQ_Cheatsheet
{

    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class Employee
    {
        public string? Name { get; set; }
        public int Salary { get; set; }
    }

    public class Product
    {
        public string? Name { get; set; }
        public double Price { get; set; }
    }

    public abstract class Animal
    {
        public string? Name { get; set; }
    }

    public class Dog : Animal
    {
        public int Age { get; set; }
    }

    public class Cat : Animal
    {
        public int Age { get; set; }
    }

    public class Bird : Animal
    {
        public string? Color { get; set; }
    }

    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Name == y.Name && x.Age == y.Age;
        }

        public int GetHashCode(Person obj)
        {
            if (ReferenceEquals(obj, null))
                return 0;

            int nameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int ageHashCode = obj.Age.GetHashCode();

            return nameHashCode ^ ageHashCode;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 3, 1, 4, 2 };

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
            // Example 1: Check if number 3 exists in the array
            int[] numbersContains = { 1, 2, 3, 4, 5 };
            bool containsNumber3 = numbersContains.Contains(3);
            // Output: True

            // Example 2: Check if name "Bob" exists in the array
            string[] namesContains = { "Alice", "Bob", "Charlie" };
            bool containsNameBob = namesContains.Contains("Bob");
            // Output: True

            // Example 3: Check if number 6 exists in the list
            List<int> numberListContains = new() { 1, 2, 3, 4, 5 };
            bool containsNumber6 = numberListContains.Contains(6);
            // Output: False

            // Example 4: Check if name "Eve" exists in the list
            List<string> namesListContains = new() { "Alice", "Bob", "Charlie" };
            bool containsNameEve = namesListContains.Contains("Eve");
            // Output: False

            // Example 5: Check if a specific object exists in a list
            List<Person> personsListContains = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 }
            };
            Person personBob = new Person { Name = "Bob", Age = 35 };
            bool containsPersonBob = personsListContains.Contains(personBob);
            // Output: True

            // Example 6: Check if two different objects with the same properties exist in a list
            List<Person> personsListContains2 = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 }
            };
            Person personBob2 = new Person { Name = "Bob", Age = 35 };
            bool containsPersonBob2 = personsListContains2.Any(person => person.Name == personBob2.Name && person.Age == personBob2.Age);
            // Output: True
            #endregion

            #region OrderBy
            // Example 1: Sort numbers in ascending order using OrderBy
            var ascendingOrder = numbers.OrderBy(num => num);
            // Output: 1, 2, 3, 4, 5

            // Example 2: Sort numbers in descending order using OrderByDescending
            var descendingOrder = numbers.OrderByDescending(num => num);
            // Output: 5, 4, 3, 2, 1

            // Example 3: Sort names in alphabetical order using OrderBy
            var alphabeticalOrder = names.OrderBy(name => name);
            // Output: Alice, Bob, Charlie

            // Example 4: Sort persons by age in ascending order using OrderBy
            var sortByAge = persons.OrderBy(person => person.Age);
            // Output: Alice, Charlie, Bob

            // Example 5: Sort persons by age in descending order using OrderByDescending
            var sortByAgeDescending = persons.OrderByDescending(person => person.Age);
            // Output: Bob, Charlie, Alice
            #endregion

            #region ThenBy
            // Example 1: Order strings by length, then alphabetically
            string[] namesThenBy = { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            var orderedNamesThenBy = namesThenBy.OrderBy(name => name.Length).ThenBy(name => name);
            // Output: Alice, Bob, Dave, Eve, Charlie

            // Example 2: Order objects by multiple properties
            List<Person> personsThenBy = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 },
                new Person { Name = "Bob", Age = 25 },
                new Person { Name = "Eve", Age = 35 }
            };
            var orderedPersonsThenBy = personsThenBy.OrderBy(person => person.Name).ThenBy(person => person.Age);
            // Output: Alice(30), Bob(25), Bob(35), Charlie(40), Eve(35)
            #endregion

            #region Min
            // Example 1: Find the minimum value in an array of integers
            int[] numbersMin = { 5, 2, 9, 1, 7 };
            int minNumber = numbersMin.Min();
            // Output: 1

            // Example 2: Find the minimum length among a list of strings
            List<string> namesMin = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            int minLength = namesMin.Min(name => name.Length);
            // Output: 3

            // Example 3: Find the minimum value based on a property in a list of objects
            List<Person> personsMin = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 },
                new Person { Name = "Dave", Age = 25 },
                new Person { Name = "Eve", Age = 35 }
            };
            int minAge = personsMin.Min(person => person.Age);
            // Output: 25
            #endregion

            #region Max
            // Example 1: Find the maximum value in an array of integers
            int[] numbersMax = { 5, 2, 9, 1, 7 };
            int maxNumber = numbersMax.Max();
            // Output: 9

            // Example 2: Find the maximum length among a list of strings
            List<string> namesMax = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            int maxLength = namesMax.Max(name => name.Length);
            // Output: 7

            // Example 3: Find the maximum value based on a property in a list of objects
            List<Person> personsMax = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 },
                new Person { Name = "Dave", Age = 25 },
                new Person { Name = "Eve", Age = 35 }
            };
            int maxAge = personsMax.Max(person => person.Age);
            // Output: 40
            #endregion

            #region Average
            // Example 1: Find the average of an array of numbers
            int[] numbersAverage = { 2, 4, 6, 8, 10 };
            double average = numbersAverage.Average();
            // Output: 6

            // Example 2: Find the average age of a list of persons
            List<Person> personsAverage = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 },
                new Person { Name = "Dave", Age = 25 },
                new Person { Name = "Eve", Age = 35 }
            };
            double averageAge = personsAverage.Average(person => person.Age);
            // Output: 33

            // Example 3: Find the average length of strings in a list
            List<string> namesAverage = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            double averageLength = namesAverage.Average(name => name.Length);
            // Output: 5
            #endregion

            #region Sum
            // Example 1: Sum all numbers in an array
            int[] numbersSum = { 1, 2, 3, 4, 5 };
            int sum = numbersSum.Sum();
            // Output: 15

            // Example 2: Sum the salaries of employees in a list
            List<Employee> employees = new()
            {
                new Employee { Name = "Alice", Salary = 5000 },
                new Employee { Name = "Bob", Salary = 6000 },
                new Employee { Name = "Charlie", Salary = 7000 },
                new Employee { Name = "Dave", Salary = 5500 },
                new Employee { Name = "Eve", Salary = 4500 }
            };
            int totalSalary = employees.Sum(employee => employee.Salary);
            // Output: 28000

            // Example 3: Sum the prices of products in a list
            List<Product> products = new()
            {
                new Product { Name = "Keyboard", Price = 50.99 },
                new Product { Name = "Mouse", Price = 25.99 },
                new Product { Name = "Monitor", Price = 199.99 },
                new Product { Name = "Headphones", Price = 79.99 },
                new Product { Name = "Speakers", Price = 99.99 }
            };
            double totalPrice = products.Sum(product => product.Price);
            // Output: 456.95
            #endregion

            #region ElementAt
            // Example 1: Get the element at a specific index
            int elementAtIndex = numbers.ElementAt(2);
            // Output: 1

            // Example 2: Get the element at a specific index or the default value
            int[] emptyArray = { };
            int elementOrDefault = emptyArray.ElementAtOrDefault(0);
            // Output: 0 (default value for int)

            // Example 3: Get the element at a specific index or the default value (out of range)
            List<string> namesElementAt = new() { "Alice", "Bob", "Charlie" };
            string elementOutOfRange = namesElementAt.ElementAtOrDefault(5);
            // Output: null (default value for string)
            #endregion

            #region First
            // Example 1: Get the first element of an array
            int firstElement = numbers.First();
            // Output: 5

            // Example 2: Get the first even number in an array
            int firstEvenNumber = numbers.First(n => n % 2 == 0);
            // Output: 4

            // Example 3: Get the first name in a list
            List<string> namesList = new() { "Alice", "Bob", "Charlie" };
            string firstName = namesList.First();
            // Output: "Alice"

            // Example 4: Get the first name starting with "B" in a list
            List<string> namesStartingWithBList = new() { "Bob", "Bella", "Ben" };
            string firstNameStartingWithB = namesStartingWithBList.First(name => name.StartsWith("B"));
            // Output: "Bob"

            // Example 5: Get the first person with a non-null name in a list
            List<Person> personsList = new()
            {
                new Person { Name = "Alice" },
                new Person { Name = "Bob" },
                new Person { Name = "Charlie" },
                new Person { Name = null },
                new Person { Name = "Eve" }
            };
            Person firstPersonWithNonNullName = personsList.First(person => person.Name != null);
            // Output: Person { Name = "Alice" }
            #endregion

            #region Last
            // Example 1: Get the last element of an array
            int lastElement = numbers.Last();
            // Output: 2

            // Example 2: Get the last even number in an array
            int lastEvenNumber = numbers.Last(n => n % 2 == 0);
            // Output: 4

            // Example 3: Get the last name in a list
            List<string> namesListLast = new() { "Alice", "Bob", "Charlie" };
            string lastName = namesListLast.Last();
            // Output: "Charlie"

            // Example 4: Get the last name starting with "B" in a list
            List<string> namesStartingWithBListLast = new() { "Bob", "Bella", "Ben" };
            string lastNameStartingWithB = namesStartingWithBListLast.Last(name => name.StartsWith("B"));
            // Output: "Ben"

            // Example 5: Get the last person with a non-null name in a list
            List<Person> personsListLast = new()
            {
                new Person { Name = "Alice" },
                new Person { Name = "Bob" },
                new Person { Name = "Charlie" },
                new Person { Name = null },
                new Person { Name = "Eve" }
            };
            Person lastPersonWithNonNullName = personsListLast.Last(person => person.Name != null);
            // Output: Person { Name = "Eve" }
            #endregion

            #region Single
            // Example 1: Get the single element from an array
            int[] numbersSingle = { 1 };
            int singleNumber = numbersSingle.Single();
            // Output: 1

            // Example 2: Get the single element from a list
            List<string> namesSingle = new() { "Alice" };
            string singleName = namesSingle.Single();
            // Output: "Alice"

            // Example 3: Get the single element with a condition from a list
            List<Person> personsSingle = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 }
            };
            Person singlePerson = personsSingle.Single(person => person.Age == 35);
            // Output: Person { Name = "Bob", Age = 35 }

            // Example 4: Get the single element from an empty list
            List<int> emptyListSingle = new();
            int singleElementEmptyList = emptyListSingle.Single();
            // Throws: System.InvalidOperationException - Sequence contains no elements

            // Example 5: Get the single element with a condition from a list with multiple matching elements
            List<Person> personsMultipleMatches = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 35 }
            };
            Person singlePersonMultipleMatches = personsMultipleMatches.Single(person => person.Age == 35);
            // Throws: System.InvalidOperationException - Sequence contains more than one matching element

            // Example 6: Get the single element from a list with no matching elements
            List<Person> personsNoMatch = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 }
            };
            Person singlePersonNoMatch = personsNoMatch.Single(person => person.Age == 25);
            // Throws: System.InvalidOperationException - Sequence contains no matching element
            #endregion

            #region Where
            // Example 1: Filter even numbers using Where
            int[] numbersWhere = { 1, 2, 3, 4, 5 };
            var evenNumbers = numbersWhere.Where(num => num % 2 == 0);
            // Output: 2, 4

            // Example 2: Filter names starting with "B" using Where
            string[] namesWhere = { "Alice", "Bob", "Charlie" };
            var namesStartingWithBWhere = namesWhere.Where(name => name.StartsWith("B"));
            // Output: Bob

            // Example 3: Filter persons older than 30 using Where
            List<Person> personsWhere = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 }
            };
            var personsOlderThan30 = personsWhere.Where(person => person.Age > 30);
            // Output: Bob, Charlie

            // Example 4: Filter products with price greater than $50 using Where
            List<Product> productsWhere = new()
            {
                new Product { Name = "Keyboard", Price = 50.99 },
                new Product { Name = "Mouse", Price = 25.99 },
                new Product { Name = "Monitor", Price = 199.99 },
                new Product { Name = "Headphones", Price = 79.99 },
                new Product { Name = "Speakers", Price = 99.99 }
            };
            var expensiveProducts = productsWhere.Where(product => product.Price > 50);
            // Output: Keyboard, Monitor, Headphones, Speakers

            // Example 5: Filter strings containing a specific substring using Where
            string[] stringsWhere = { "apple", "banana", "cherry", "date", "elderberry" };
            var stringsContainingA = stringsWhere.Where(str => str.Contains("a"));
            // Output: apple, banana, date, elderberry

            // Example 6: Filter even-length names starting with "A" using Where
            List<string> namesListWhere = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            var filteredNames = namesListWhere.Where(name => name.Length % 2 == 0 && name.StartsWith("A"));
            // Output: Alice
            #endregion

            #region Take
            // Example 1: Take the first three elements from an array
            int[] numbersTake = { 1, 2, 3, 4, 5 };
            var takenNumbers = numbersTake.Take(3);
            // Output: 1, 2, 3

            // Example 2: Take the first two names from a list
            List<string> namesTake = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            var takenNames = namesTake.Take(2);
            // Output: Alice, Bob

            // Example 3: Take the first three even numbers from a list
            List<int> evenNumbersTake = new() { 2, 4, 6, 7, 8, 10 };
            var takenEvenNumbers = evenNumbersTake.Where(n => n % 2 == 0).Take(3);
            // Output: 2, 4, 6

            // Example 4: Take the first three persons with an age less than 40 from a list
            List<Person> personsTake = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 },
                new Person { Name = "Dave", Age = 25 },
                new Person { Name = "Eve", Age = 35 },
                new Person { Name = "Frank", Age = 45 }
            };
            var takenPersons = personsTake.Where(p => p.Age < 40).Take(3);
            // Output: Alice(30), Bob(35), Charlie(40)
            #endregion

            #region TakeLast
            // Example 1: Take the last three elements from an array
            int[] numbersTakeLast = { 1, 2, 3, 4, 5 };
            var takenLastNumbers = numbersTakeLast.TakeLast(3);
            // Output: 3, 4, 5

            // Example 2: Take the last two names from a list
            List<string> namesTakeLast = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            var takenLastNames = namesTakeLast.TakeLast(2);
            // Output: Dave, Eve

            // Example 3: Take the last three even numbers from a list
            List<int> evenNumbersTakeLast = new() { 2, 4, 6, 7, 8, 10 };
            var takenLastEvenNumbers = evenNumbersTakeLast.Where(n => n % 2 == 0).TakeLast(3);
            // Output: 8, 10

            // Example 4: Take the last three persons with an age less than 40 from a list
            List<Person> personsTakeLast = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 },
                new Person { Name = "Dave", Age = 25 },
                new Person { Name = "Eve", Age = 35 },
                new Person { Name = "Frank", Age = 45 }
            };
            var takenLastPersons = personsTakeLast.Where(p => p.Age < 40).TakeLast(3);
            // Output: Dave(25), Eve(35), Frank(45)
            #endregion

            #region TakeWhile
            // Example 1: Take numbers while less than 4
            int[] numbersTakeWhile = { 1, 2, 3, 4, 5 };
            var takenNumbersWhile = numbersTakeWhile.TakeWhile(num => num < 4);
            // Output: 1, 2, 3

            // Example 2: Take names while starting with 'B'
            List<string> namesTakeWhile = new() { "Bob", "Bella", "Ben", "Charlie" };
            var takenNamesWhile = namesTakeWhile.TakeWhile(name => name.StartsWith("B"));
            // Output: Bob, Bella, Ben

            // Example 3: Take persons while age is less than 40
            List<Person> personsTakeWhile = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 },
                new Person { Name = "Dave", Age = 25 },
                new Person { Name = "Eve", Age = 35 }
            };
            var takenPersonsWhile = personsTakeWhile.TakeWhile(person => person.Age < 40);
            // Output: Alice(30), Bob(35)
            #endregion

            #region Skip
            // Example 1: Skip elements in an array
            int[] numbersSkip = { 1, 2, 3, 4, 5 };
            var skippedNumbers = numbersSkip.Skip(2);
            // Output: 3, 4, 5

            // Example 2: Skip elements in a list
            List<string> namesSkip = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            var skippedNames = namesSkip.Skip(3);
            // Output: Dave, Eve

            // Example 3: Skip elements while a condition is met
            int[] numbersSkipWhile = { 1, 2, 3, 4, 5 };
            var skippedNumbersWhile = numbersSkipWhile.SkipWhile(num => num < 3);
            // Output: 3, 4, 5

            // Example 4: Skip elements until a condition is met
            List<string> namesSkipUntil = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            var skippedNamesUntil = namesSkipUntil.SkipWhile(name => name != "Dave").Skip(1);
            // Output: Dave, Eve

            // Example 5: Skip elements dynamically based on a variable
            int[] numbersDynamicSkip = { 1, 2, 3, 4, 5 };
            int skipCount = 3;
            var skippedNumbersDynamic = numbersDynamicSkip.Skip(skipCount);
            // Output: 4, 5

            // Example 6: Exception: ArgumentOutOfRangeException if skip count is greater than the number of elements
            int[] numbersSkipOutOfRange = { 1, 2, 3, 4, 5 };
            int skipCountOutOfRange = 10;
            var skippedNumbersOutOfRange = numbersSkipOutOfRange.Skip(skipCountOutOfRange);
            // Exception: System.ArgumentOutOfRangeException: 'Argument out of range: skipCount'

            // Example 7: Mistake: Forgetting to call ToList() or ToArray() after skipping elements
            List<int> numbersSkipMistake = new() { 1, 2, 3, 4, 5 };
            var skippedNumbersMistake = numbersSkipMistake.Skip(2);
            numbersSkipMistake.Add(6); // Modifying the original list
                                       // Output: 3, 4, 5, 6 (Original list modification affects skipped elements)
            #endregion

            #region OfType
            // Example 1: Filter objects based on their type
            object[] mixedObjects = { "Alice", 1, "Bob", 2.5, "Charlie", 3 };
            var filteredStrings = mixedObjects.OfType<string>();
            // Output: "Alice", "Bob", "Charlie"

            // Example 2: Filter objects based on their type and condition
            object[] mixedObjects2 = { "Alice", 1, "Bob", 2.5, "Charlie", 3 };
            var filteredIntegers = mixedObjects2.OfType<int>().Where(num => num % 2 == 0);
            // Output: 2

            // Example 3: Filter objects based on a derived type
            Animal[] animals = { new Dog(), new Cat(), new Dog(), new Bird() };
            var filteredDogs = animals.OfType<Dog>();
            // Output: Dog, Dog

            // Example 4: Filter objects based on a derived type and condition
            Animal[] animals2 = { new Dog(), new Cat(), new Dog(), new Bird() };
            var filteredCats = animals2.OfType<Cat>().Where(cat => cat.Age > 2);
            // Output: Cat
            #endregion

            #region Distinct
            // Example 1: Get distinct numbers from an array
            int[] numbersDistinct = { 1, 2, 3, 4, 4, 5, 5 };
            var distinctNumbers = numbersDistinct.Distinct();
            // Output: 1, 2, 3, 4, 5

            // Example 2: Get distinct names from a list
            List<string> namesDistinct = new() { "Alice", "Bob", "Charlie", "Alice", "Bob" };
            var distinctNames = namesDistinct.Distinct();
            // Output: Alice, Bob, Charlie

            // Example 3: Get distinct objects based on a property in a list
            List<Person> personsDistinct = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Alice", Age = 30 }
            };
            var distinctPersons = personsDistinct.Distinct();
            // Output: Alice(30), Bob(35)

            // Example 4: Get distinct objects based on a specific property in a list
            List<Person> personsDistinctByAge = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Alice", Age = 30 }
            };
            var distinctPersonsByAge = personsDistinctByAge.DistinctBy(person => person.Age);
            // Output: Alice(30), Bob(35)

            // Example 5: Get distinct objects with a custom equality comparer
            List<Person> personsDistinctWithComparer = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Alice", Age = 30 }
            };
            var distinctPersonsWithComparer = personsDistinctWithComparer.Distinct(new PersonEqualityComparer());
            // Output: Alice(30), Bob(35)
            #endregion

            #region Except
            // Example 1: Get elements from the first array that do not exist in the second array
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 3, 4, 5, 6, 7 };
            var resultExcept = array1.Except(array2);
            // Output: 1, 2

            // Example 2: Get names from the first list that do not exist in the second list
            List<string> list1 = new() { "Alice", "Bob", "Charlie" };
            List<string> list2 = new() { "Bob", "Charlie", "Dave" };
            var resultExceptNames = list1.Except(list2);
            // Output: Alice

            // Example 3: Get objects from the first list that do not exist in the second list based on a property
            List<Person> personList1 = new()
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 }
            };
            List<Person> personList2 = new()
            {
                new Person { Name = "Bob", Age = 35 },
                new Person { Name = "Charlie", Age = 40 },
                new Person { Name = "Dave", Age = 45 }
            };
            var resultExceptPersons = personList1.Except(personList2, new PersonEqualityComparer());
            // Output: Alice(30)
            #endregion

            #region Prepend and Append
            // Example 1: Prepend a number to an array
            int[] numbersPrepend = { 2, 3, 4, 5 };
            int[] numbersPrepended = Enumerable.Range(1, 1).Concat(numbersPrepend).ToArray();
            // Output: 1, 2, 3, 4, 5

            // Example 2: Append a number to an array
            int[] numbersAppend = { 1, 2, 3, 4 };
            int[] numbersAppended = numbersAppend.Concat(5).ToArray();
            // Output: 1, 2, 3, 4, 5

            // Example 3: Prepend an item to a list
            List<string> namesPrepend = new() { "Bob", "Charlie" };
            namesPrepend.Insert(0, "Alice");
            // Output: "Alice", "Bob", "Charlie"

            // Example 4: Append an item to a list
            List<string> namesAppend = new() { "Alice", "Bob" };
            namesAppend.Add("Charlie");
            // Output: "Alice", "Bob", "Charlie"

            // Example 5: Prepend a range of numbers to a list
            List<int> numbersListPrepend = new() { 3, 4, 5 };
            numbersListPrepend.InsertRange(0, new[] { 1, 2 });
            // Output: 1, 2, 3, 4, 5

            // Example 6: Append a range of numbers to a list
            List<int> numbersListAppend = new() { 1, 2, 3 };
            numbersListAppend.AddRange(new[] { 4, 5 });
            // Output: 1, 2, 3, 4, 5

            // Exception: InvalidOperationException
            // Occurs when using methods like Prepend, Append, Insert, or Add on a collection that does not support modification.
            List<int> readOnlyList = new()
            {
                1,
                2,
                3,
                4
            };
            // InvalidOperationException: Collection was of a fixed size.

            // Mistake: Forgetting to assign the result of Prepend or Append methods.
            int[] numbersPA = { 1, 2, 3 };
            numbersPA.Prepend(0);
            // The original numbers array remains unchanged.

            // Mistake: Using Concat to append a single element instead of using Append.
            int[] numbersConcat = { 1, 2, 3 };
            int[] numbersIncorrect = numbersConcat.Concat(new[] { 4 }).ToArray();
            // Less efficient than using Append.

            // Mistake: Forgetting to update the original list after using Insert or Add methods.
            List<string> namesListPA = new() { "Alice", "Bob" };
            namesListPA.Insert(0, "Charlie");
            // The namesList is not updated to include the inserted item.
            #endregion



        }
    }
}