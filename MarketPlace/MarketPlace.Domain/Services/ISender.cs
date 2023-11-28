namespace MarketPlace.Domain.Services
{
    public interface ISender
    {
        string SendNotification(string to);
    }
}
