namespace MarketPlace.Domain.ValueObjects
{
    public class ClassifiedAdId
    {
        private readonly Guid id;

        public ClassifiedAdId(Guid guid)
        {
            if (guid == default)
            {
                throw new ArgumentException("Id değeri belirtilmeli", nameof(id));
            }
            this.id = guid;
        }
    }
}
