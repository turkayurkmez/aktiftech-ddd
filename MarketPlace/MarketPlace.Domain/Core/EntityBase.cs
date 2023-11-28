namespace MarketPlace.Domain.Core
{
    public abstract class EntityBase
    {
        private readonly List<object> events = new List<object>();
        protected void Raise(object @event) => events.Add(@event);
        public void Clear() => events.Clear();

        public IEnumerable<object> GetEvents() => events.AsEnumerable();

        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            events.Add(@event);

        }

        public abstract void When(object @event);
        public abstract void EnsureValidState();



    }
}
