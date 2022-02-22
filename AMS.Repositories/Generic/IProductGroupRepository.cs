using AMS.Entities;
using AMS.Model; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.Repositories.Generic
{
    public interface IProductGroupRepository
    {
        List<CollectionViewModel> GetProductGroup();
        ProductGroup GetProductGroupById(int id); 
    }
}