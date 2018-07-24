namespace Google
{
    using System;

    public class Pokemon
    {
        public Pokemon(string pokemonName, string pokemonType)
        {
            this.pokemonName = pokemonName;
            this.pokemonType = pokemonType;
        }

        private string pokemonName;
        private string pokemonType;
        
        public string PokemonName
        {
            get => pokemonName;
            set => pokemonName = value;
        }

        public string PokemonType
        {
            get => pokemonType;
            set => pokemonType = value;
        }

        public static Pokemon Parse(string input)
        {
            var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Pokemon Parse(string[] input)
        {
            var pokemonName = input[0];
            var pokemonType = input[1];

            return new Pokemon(pokemonName, pokemonType);
        }

        public override string ToString()
        {
            return $"{this.PokemonName} {this.PokemonType}" + Environment.NewLine;
        }
    }
}
