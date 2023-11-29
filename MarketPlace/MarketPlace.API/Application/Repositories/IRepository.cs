using MarketPlace.Domain;
using MarketPlace.Domain.ValueObjects;

namespace MarketPlace.API.Application.Repositories
{
    public interface IRepository<T>
    {
        Task<int> Save(T entity);
        Task<T> GetById(Guid id);
    }

    public class FakeRepository : IRepository<ClassifiedAd>
    {
        public async Task<ClassifiedAd> GetById(Guid id)
        {
            await Task.CompletedTask;
            return new ClassifiedAd(new ClassifiedAdId(Guid.NewGuid()), new UserId(Guid.NewGuid()), null);
        }

        public async Task<int> Save(ClassifiedAd entity)
        {
            await Task.CompletedTask;

            return new Random().Next(1, 3000);

        }
    }
}
