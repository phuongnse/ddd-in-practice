namespace DDDInPractice.Logic
{
    public class Snack : AggregateRoot
    {
        protected Snack()
        {
        }

        public Snack(string name)
        {
            Name = name;
        }

        public virtual string Name { get; protected set; }
    }
}