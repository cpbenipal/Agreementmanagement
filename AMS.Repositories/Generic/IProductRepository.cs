using AMS.Entities;
using AMS.Model; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.Repositories.Generic
{
    public interface IProductRepository
    {
        List<CollectionViewModel> GetProducts();
        List<CollectionViewModel> GetProductsById(int? id);
        Product GetProductById(int id);  
    }
}