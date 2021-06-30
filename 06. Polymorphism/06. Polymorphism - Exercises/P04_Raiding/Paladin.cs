namespace P04_Raiding
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name) 
            : base(name, PaladinPower)
        {
        }

        public override string CastAbility()
            => $"{nameof(Paladin)} - {this.Name} healed for {this.Power}";
    }
}
