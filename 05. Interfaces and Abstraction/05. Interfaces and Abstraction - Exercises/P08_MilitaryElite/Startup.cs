namespace P08_MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Solders.Interfaces;
    using Solders.SpecialisedSoldiers.Commandos;
    using Solders.SpecialisedSoldiers.Commandos.Enums;
    using Solders.Spys;

    public class Startup
    {
        public static void Main()
        {
            var inputLine = string.Empty;

            var listOfAllSolders = new List<ISoldier>();

            var listOfPrivates = new List<Private>();

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(' ');

                var typeOfSolder = tokens[0];
                var id = int.Parse(tokens[1]);
                var firstname = tokens[2];
                var lastname = tokens[3];

                Private currentSolder = null;

                switch (typeOfSolder)
                {
                    case "Private":
                        var salary = decimal.Parse(tokens[4]);
                        currentSolder = new Private(id, firstname, lastname, salary);
                        listOfPrivates.Add(currentSolder);
                        listOfAllSolders.Add(currentSolder);
                        break;
                    case "LeutenantGeneral":
                        salary = decimal.Parse(tokens[4]);
                        var privates = ParsePrivates(tokens, listOfPrivates);
                        currentSolder = new LeutenantGeneral(id, firstname, lastname, salary, privates);
                        listOfPrivates.Add(currentSolder);
                        listOfAllSolders.Add(currentSolder);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(tokens[4]);
                        var parsed = Enum.TryParse(tokens[5], out Corps corps);
                        if (parsed)
                        {
                            var repaires = ParseRepairs(tokens);
                            currentSolder = new Engineer(id, firstname, lastname, salary, corps, repaires);
                            listOfPrivates.Add(currentSolder);
                            listOfAllSolders.Add(currentSolder);
                        }
                        break;
                    case "Commando":
                        salary = decimal.Parse(tokens[4]);
                        parsed = Enum.TryParse(tokens[5], out corps);
                        if (parsed)
                        {
                            var missions = ParseMissions(tokens);
                            currentSolder = new Commando(id, firstname, lastname, salary, corps, missions);
                            listOfPrivates.Add(currentSolder);
                            listOfAllSolders.Add(currentSolder);
                        }
                        break;
                    case "Spy":
                        var codeNumber = int.Parse(tokens[4]);
                        var currentSpy = new Spy(id, firstname, lastname, codeNumber);
                        listOfAllSolders.Add(currentSpy);
                        break;
                }
            }

            listOfAllSolders.ForEach(Console.WriteLine);
        }

        private static List<Mission> ParseMissions(string[] tokens)
        {
            if (tokens.Length == 6)
            {
                return new List<Mission>();
            }

            var result = new List<Mission>();

            var missionData = tokens.Skip(6).ToArray();

            for (var i = 0; i < missionData.Length / 2; i++)
            {
                var currentIndex = i * 2;
                var partName = missionData[currentIndex];
                var parsed = Enum.TryParse(missionData[currentIndex + 1], out MissionState missionState);

                if (parsed)
                {
                    var currentRepair = new Mission(partName, missionState);
                    result.Add(currentRepair);
                }
            }

            return result;
        }

        private static List<Repair> ParseRepairs(string[] tokens)
        {
            if (tokens.Length == 6)
            {
                return new List<Repair>();
            }

            var repairData = tokens.Skip(6).ToArray();

            var result = new List<Repair>();

            for (var i = 0; i < repairData.Length / 2; i++)
            {
                var currentIndex = i * 2;
                var partName = repairData[currentIndex];
                var hours = int.Parse(repairData[currentIndex + 1]);
                var currentRepair = new Repair(partName, hours);
                result.Add(currentRepair);
            }

            return result;
        }

        private static List<Private> ParsePrivates(string[] tokens, List<Private> solders)
        {
            if (tokens.Length == 5)
            {
                return new List<Private>();
            }

            var result = tokens
                .Skip(5)
                .Select(int.Parse)
                .Select(x => solders.FirstOrDefault(y => y.Id == x))
                .Where(x => x != null)
                .ToList();

            return result;
        }
    }
}
