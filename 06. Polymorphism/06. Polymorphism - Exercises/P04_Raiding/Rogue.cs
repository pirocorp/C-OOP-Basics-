namespace P04_Raiding
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;

        public Rogue(string name) 
            : base(name, RoguePower)
        {
        }

        public override string CastAbility()
            => $"{nameof(Rogue)} - {this.Name} hit for {this.Power} damage";
    }
}
