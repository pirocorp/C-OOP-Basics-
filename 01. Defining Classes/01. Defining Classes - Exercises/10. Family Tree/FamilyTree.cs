namespace _10._Family_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FamilyTree
    {
        public static void Main()
        {
            var searchInput = Console.ReadLine();

            var family = new List<Person>();

            var inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "End")
            {
                if (inputLine.Contains("-"))
                {
                    if (inputLine.Contains("/"))
                    {
                        var tokens = inputLine
                            .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToArray();

                        var leftPart = tokens[0];
                        var rightPart = tokens[1];

                        if (leftPart.Contains("/") && rightPart.Contains("/"))
                        {
                            var firstPersonBirthday = leftPart; //Parent
                            var secondPersonBirthday = rightPart; //Child

                            Person firstPerson = null;
                            Person secondPerson = null;

                            if (family.Where(x => x.BirthDate != null)
                                .Any(x => x.BirthDate.BirthDate == firstPersonBirthday))
                            {
                                firstPerson = family.Where(x => x.BirthDate != null)
                                    .First(x => x.BirthDate.BirthDate == firstPersonBirthday);
                            }
                            else
                            {
                                firstPerson = new Person(new Birthdate(firstPersonBirthday));
                                family.Add(firstPerson);
                            }

                            if (family.Where(x => x.BirthDate != null)
                                .Any(x => x.BirthDate.BirthDate == secondPersonBirthday))
                            {
                                secondPerson = family.Where(x => x.BirthDate != null)
                                    .First(x => x.BirthDate.BirthDate == secondPersonBirthday);
                            }
                            else
                            {
                                secondPerson = new Person(new Birthdate(secondPersonBirthday));
                                family.Add(secondPerson);
                            }

                            firstPerson.Children.Add(secondPerson);
                            secondPerson.Parents.Add(firstPerson);
                        }
                        else if (leftPart.Contains("/"))
                        {
                            var firstPersonBirthday = leftPart; //Parent
                            var secondPersonName = rightPart; // Child

                            Person firstPerson = null;
                            Person secondPerson = null;

                            if (family.Where(x => x.BirthDate != null)
                                .Any(x => x.BirthDate.BirthDate == firstPersonBirthday))
                            {
                                firstPerson = family.Where(x => x.BirthDate != null)
                                    .First(x => x.BirthDate.BirthDate == firstPersonBirthday);
                            }
                            else
                            {
                                firstPerson = new Person(new Birthdate(firstPersonBirthday));
                                family.Add(firstPerson);
                            }

                            if (family.Where(x => x.Name != null).Any(x => x.Name == secondPersonName))
                            {
                                secondPerson = family.Where(x => x.Name != null).First(x => x.Name == secondPersonName);
                            }
                            else
                            {
                                secondPerson = new Person(secondPersonName);
                                family.Add(secondPerson);
                            }

                            firstPerson.Children.Add(secondPerson);
                            secondPerson.Parents.Add(firstPerson);
                        }
                        else
                        {
                            var firstPersonName = leftPart; //Parent
                            var secondPersonBirthday = rightPart; //Child

                            Person firstPerson = null;
                            Person secondPerson = null;

                            if (family.Any(x => x.Name == firstPersonName))
                            {
                                firstPerson = family.First(x => x.Name == firstPersonName);
                            }
                            else
                            {
                                firstPerson = new Person(firstPersonName);
                                family.Add(firstPerson);
                            }

                            if (family.Where(x => x.BirthDate != null)
                                .Any(x => x.BirthDate.BirthDate == secondPersonBirthday))
                            {
                                secondPerson = family.Where(x => x.BirthDate != null)
                                    .First(x => x.BirthDate.BirthDate == secondPersonBirthday);
                            }
                            else
                            {
                                secondPerson = new Person(new Birthdate(secondPersonBirthday));
                                family.Add(secondPerson);
                            }

                            firstPerson.Children.Add(secondPerson);
                            secondPerson.Parents.Add(firstPerson);
                        }
                    }
                    else
                    {
                        var tokens = inputLine
                            .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToArray();

                        var firstPersonName = tokens[0]; //Parent
                        var secondPersonName = tokens[1]; //Child

                        Person firstPerson = null;
                        Person secondPerson = null;

                        if (family.Where(x => x.Name != null).Any(x => x.Name == firstPersonName))
                        {
                            firstPerson = family.Where(x => x.Name != null).First(x => x.Name == firstPersonName);
                        }
                        else
                        {
                            firstPerson = new Person(firstPersonName);
                            family.Add(firstPerson);
                        }

                        if (family.Where(x => x.Name != null).Any(x => x.Name == secondPersonName))
                        {
                            secondPerson = family.Where(x => x.Name != null).First(x => x.Name == secondPersonName);
                        }
                        else
                        {
                            secondPerson = new Person(secondPersonName);
                            family.Add(secondPerson);
                        }

                        firstPerson.Children.Add(secondPerson);
                        secondPerson.Parents.Add(firstPerson);
                    }
                }
                else
                {
                    var tokens = inputLine
                        .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    var lastIndexOfSpace = inputLine.LastIndexOf(" ", StringComparison.Ordinal);

                    var personName = inputLine.Substring(0, lastIndexOfSpace);
                    var personBirthday = new Birthdate(inputLine.Substring(lastIndexOfSpace + 1));

                    Person currentPerson = null;

                    if (family.Any(x => x.Name == personName) && family.Where(x => x.BirthDate != null).Any(x => x.BirthDate.BirthDate == personBirthday.BirthDate))
                    {
                        var resultByName = family.Where(x => x.Name != null).First(x => x.Name == personName);

                        var resultByBirthday = family.Where(x => x.BirthDate != null)
                            .First(x => x.BirthDate.BirthDate == personBirthday.BirthDate);

                        var childrenFromResultByBirthday = resultByBirthday.Children;
                        var parentsFromResultByBirthday = resultByBirthday.Parents;
                        var birthday = resultByBirthday.BirthDate;

                        resultByName.BirthDate = birthday;
                        resultByName.Children.AddRange(childrenFromResultByBirthday);
                        resultByName.Parents.AddRange(parentsFromResultByBirthday);

                        family.Remove(resultByBirthday);
                    }
                    else if (family.Where(x => x.Name != null).Any(x => x.Name == personName))
                    {
                        currentPerson = family.Where(x => x.Name != null).First(x => x.Name == personName);
                        currentPerson.BirthDate = personBirthday;
                    }
                    else if (family.Where(x => x.BirthDate != null).Any(x => x.BirthDate.BirthDate == personBirthday.BirthDate))
                    {
                        currentPerson = family.Where(x => x.BirthDate != null).First(x => x.BirthDate.BirthDate == personBirthday.BirthDate);
                        currentPerson.Name = personName;
                    }
                    else
                    {
                        currentPerson = new Person(personName, personBirthday);
                        family.Add(currentPerson);
                    }
                }
            }

            Person result = null;

            if (searchInput.Contains("/"))
            {
                result = family.Where(x => x.BirthDate != null).FirstOrDefault(x => x.BirthDate.BirthDate == searchInput);
            }
            else
            {
                result = family.Where(x => x.Name != null).First(x => x.Name == searchInput);
            }

            if (result != null)
            {
                ProcessResult(result, family);

                Console.WriteLine(result);
                Console.WriteLine($"Parents:");
                result.Parents.ForEach(x => Console.WriteLine(x));
                Console.WriteLine($"Children:");
                result.Children.ForEach(x => Console.WriteLine(x));
            }
        }

        private static void ProcessResult(Person result, List<Person> family)
        {
            var currentChildren = result.Children;

            foreach (var child in currentChildren)
            {
                if (child.BirthDate == null || child.Name == null)
                {
                    if (child.Name == null)
                    {
                        child.Name = family.Where(x => x.BirthDate != null).First(x => x.BirthDate.BirthDate == child.BirthDate.BirthDate).Name;
                    }
                    else
                    {
                        child.BirthDate = family.Where(x => x.Name != null).First(x => x.Name == child.Name).BirthDate;
                    }
                }
            }

            var currentParents = result.Parents;

            foreach (var parent in currentParents)
            {
                if (parent.BirthDate == null || parent.Name == null)
                {
                    if (parent.Name == null)
                    {
                        parent.Name = family.Where(x => x.BirthDate != null)
                            .First(x => x.BirthDate.BirthDate == parent.BirthDate.BirthDate).Name;
                    }
                    else
                    {
                        parent.BirthDate = family.Where(x => x.Name != null).First(x => x.Name == parent.Name).BirthDate;
                    }
                }
            }
        }
    }
}