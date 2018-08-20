namespace DungeonsAndCodeWizards.Factories
{
    using Entities;
    using Entities.Characters;
    using Enums;
    using System;
    using Utilities;

    public class CharacterFactory
    {
        public Character CreateCharacter(string factionAsString, string type, string name)
        {
            var isParsed = Enum.TryParse<Faction>(factionAsString, out var faction);

            if (!isParsed)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidFaction, factionAsString));
            }

            Character newCharacter = null;

            switch (type)
            {
                case "Cleric":
                    newCharacter = new Cleric(name, faction);
                    break;

                case "Warrior":
                    newCharacter = new Warrior(name, faction);
                    break;

                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }

            return newCharacter;
        }
    }
}