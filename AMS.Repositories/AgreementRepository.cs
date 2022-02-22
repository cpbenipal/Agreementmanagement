using System.Linq;
using System;
using AMS.Repositories.Generic;
using AMS.Entities;
using System.Linq.Dynamic.Core;
using AMS.Model; 
using Microsoft.AspNetCore.Identity;

namespace AMS.Repositories
{
    public class AgreementRepository : IAgreementRepository
    {
        private IRepository<Agreement> agmtrepository;
        private IProductRepository prodrepository;
        private IProductGroupRepository prodgrepository;
        private IRepository<IdentityUser> sitory;
       // private readonly ApplicationDbContext context;
        
        public AgreementRepository(IRepository<IdentityUser> _sitory, IRepository<Agreement> _agmtrepository, IProductRepository _prodrepository, IProductGroupRepository _prodgrepository)
        {
            agmtrepository = _agmtrepository;
            prodrepository = _prodrepository;
            prodgrepository = _prodgrepository;
            //this.context = new ApplicationDbContext();
            sitory = _sitory;
        }
        public NewAgreeViewModel AddEdit(int? id)
        {
            NewAgreeViewModel model = new NewAgreeViewModel();
            model.Groups = prodgrepository.GetProductGroup();

            model.Products = prodrepository.GetProducts();

            model.Active = true;

            if (id.HasValue)
            {
                model.Id = id.Value;
                var entity = agmtrepository.GetById(model.Id);
                model.Product = entity.ProductId;
                model.Group = entity.ProductGroupId;
                model.EffectiveDate = entity.EffectiveDate;
                model.ExpirationDate = entity.ExpirationDate;
                model.NewPrice = entity.NewPrice;
                model.ProductPrice = entity.ProductPrice;
                model.Active = true;
            }
            return model;
        }

        public AgreementListViewModel GetAgreements(
            string draw,
            string start,
            string length,
            string sortColumn,
            string sortColumnDirection,
            string searchValue
            )
        {
            try
            {
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                 

                var users = sitory.GetAll();
                 

                var model = (from agr in agmtrepository.GetAll()
                             join user in users on agr.User.Id equals user.Id
                             join prod in prodrepository.GetProducts() on agr.Product.Id equals prod.Id
                             join prodgrp in prodgrepository.GetProductGroup() on agr.ProductGroup.Id equals prodgrp.Id
                             select new AgreementViewModel
                             {
                                 Username = user.UserName,
                                 GroupCode = prodgrp.Code,
                                 GroupDescription = prodgrp.Description,
                                 ProductDescription = prod.Description,
                                 ProductNumber = prod.Code,
                                 EffectiveDate = agr.EffectiveDate.ToShortDateString(),
                                 ExpirationDate = agr.ExpirationDate.ToShortDateString(),
                                 ProductPrice = agr.ProductPrice,
                                 NewPrice = agr.NewPrice,
                                 Id = agr.AgreementId
                             }).AsQueryable();

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    model = model.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    model = model.Where(m => m.ProductNumber.Contains(searchValue)
                                        || m.GroupCode.Contains(searchValue)
                                        || m.Username.Contains(searchValue));
                }
                recordsTotal = model.Count();
                var data = model.Skip(skip).Take(pageSize).ToList();
                var jsonData = new AgreementListViewModel
                {
                    draw = draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal = recordsTotal,
                    data = data
                };
                return jsonData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int DeleteAgreement(int Id)
        {
            agmtrepository.Delete(Id);
            return agmtrepository.Save();
        }
        public int SaveAgreement(NewAgreeViewModel unit)
        {
            Agreement entity = null;
            if (unit.Id > 0)
            {
                entity = agmtrepository.GetById(unit.Id);              
            }
            else
            {
                entity = new Agreement();                                
            }
            entity.Product = prodrepository.GetProductById(Convert.ToInt32(unit.Product));
            entity.ProductGroup = prodgrepository.GetProductGroupById(Convert.ToInt32(unit.Group));
            entity.EffectiveDate = unit.EffectiveDate;
            entity.ExpirationDate = unit.ExpirationDate;
            entity.NewPrice = unit.NewPrice;
            entity.ProductPrice = entity.Product.Price;

            entity.User = sitory.GetById(unit.UserId); //context.Users.FirstOrDefault(x => x.Id == unit.UserId);             


            if (unit.Id > 0)
            { 
                agmtrepository.Update(entity);
            }
            else
            {
                agmtrepository.Insert(entity);
            }
            return agmtrepository.Save();
        }


    }
}

