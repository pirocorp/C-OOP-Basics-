namespace P04_Raiding
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;

        public Druid(string name) 
            : base(name, DruidPower)
        {
        }

        public override string CastAbility()
            => $"{nameof(Druid)} - {this.Name} healed for {this.Power}";
    }
}
