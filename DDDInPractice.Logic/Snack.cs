namespace DDDInPractice.Logic
{
    public class Snack : Entity
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