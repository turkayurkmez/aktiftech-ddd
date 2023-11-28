namespace MarketPlace.Domain.Services
{
    public class FakeSender : ISender
    {
        public string SendNotification(string to)
        {
            return $"{to} gönderildi";
        }
    }
}
