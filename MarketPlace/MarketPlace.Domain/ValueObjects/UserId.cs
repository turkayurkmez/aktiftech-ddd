namespace MarketPlace.Domain.ValueObjects
{
    public class UserId
    {
        private readonly Guid guid;

        public UserId(Guid guid)
        {
            if (guid == default)
            {
                throw new ArgumentException("Id değeri belirtilmeli", nameof(guid));
            }
            this.guid = guid;

        }
    }
}
