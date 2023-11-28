using MarketPlace.Domain;

namespace MarketPlace.API.Application.Repositories
{
    public interface IRepository<T>
    {
        Task<int> Save(T entity);
    }

    public class FakeRepository : IRepository<ClassifiedAd>
    {
        public async Task<int> Save(ClassifiedAd entity)
        {
            await Task.CompletedTask;

            return new Random().Next(1, 3000);

        }
    }
}
