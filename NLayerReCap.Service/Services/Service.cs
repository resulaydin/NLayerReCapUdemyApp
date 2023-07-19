using NLayerReCap.Core.Repository;
using NLayerReCap.Core.Services;
using NLayerReCap.Core.UnitOfWorks;
using NLayerReCap.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayerReCap.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;

        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            // Soru : Burada neden commit yapılmadı.
            return await _repository.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //return _repository.GetByIdAsync(id);

            var hasProduct= await _repository.GetByIdAsync(id);
            if (hasProduct==null)
            {
                throw new NotFoundException($"{typeof(T).Name}- {id} not found");
            }

            return hasProduct;
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();

        }

        public async Task Update(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
