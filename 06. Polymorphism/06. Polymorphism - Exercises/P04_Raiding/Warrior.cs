namespace P04_Raiding
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;

        public Warrior(string name) 
            : base(name, WarriorPower)
        {
        }

        public override string CastAbility()
            => $"{nameof(Warrior)} - {this.Name} hit for {this.Power} damage";
    }
}
