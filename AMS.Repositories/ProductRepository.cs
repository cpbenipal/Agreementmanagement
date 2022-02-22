using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AMS.Repositories.Generic; 
using AMS.Entities;
using AMS.Model; 

namespace AMS.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IRepository<Product> repository;

        //public ProductRepository()
        //{
        //}

        public ProductRepository(IRepository<Product> _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Get Product by group id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CollectionViewModel> GetProductsById(int? id)
        {    
            return (from x in repository.GetAll()
                    .AsQueryable()
                    where x.ProductGroup.Id  == id
                    select new CollectionViewModel()
           {
               Id = x.Id,
               Description = x.ProductDescription
           }).OrderBy(o => o.Description).ToList();
        }
        public List<CollectionViewModel> GetProducts()
        {
            return (from x in repository.GetAll()                    
                    select new CollectionViewModel()
                    {
                        Id = x.Id,
                        Description = x.ProductDescription
                    }).OrderBy(o => o.Description).ToList();
        }
        public Product GetProductById(int id)
        { 
            return repository.GetById(id);
        }
    }
}
