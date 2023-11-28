namespace MarketPlace.Domain.Events
{
    public static class DomainEvents
    {
        //Eğer bu olay microservice mimarisinde de kullanılacak ise 
        //Serializable olmak zorundaddır!
        public class ClassifiedAdCreated
        {
            public Guid Id { get; set; }
            public Guid OwnerId { get; set; }
        }

        public class ClassifiedAdTitleChanged
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
        }

        public class ClassifiedAdTextChanged
        {
            public Guid Id { get; set; }
            public string Text { get; set; }
        }

        public class ClassifiedAdPriceChanged
        {
            public Guid Id { get; set; }
            public decimal Price { get; set; }
            public string CurrencyCode { get; set; }
        }

        public class ClassifiedAdSentForReview
        {
            public Guid Id { get; set; }
        }


    }
}
