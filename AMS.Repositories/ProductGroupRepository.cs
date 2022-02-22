using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AMS.Repositories.Generic;
using AMS.DbContext.Data;
using AMS.Entities;
using AMS.Model;
using AutoMapper;

namespace AMS.Repositories
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private IRepository<ProductGroup> repository;
        //public ProductGroupRepository()
        //{
        //}
        public ProductGroupRepository(IRepository<ProductGroup> _repository)
        {
            repository = _repository;
        }
        public List<CollectionViewModel> GetProductGroup()
        { 
            return repository.GetAll()
           .Select(x => new CollectionViewModel()
           {
               Id = x.Id,
               Description = x.GroupDescription,
               Code = x.GroupCode,
           }).OrderBy(o => o.Description).ToList();
        }
        public ProductGroup GetProductGroupById(int id)
        {
            return repository.GetById(id);
        }
    }
}
