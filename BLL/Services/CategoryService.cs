using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICategoryService
    {
        public IQueryable<CategoryModel> Query();
        //We need method definitions:

        public Service Create(Category record);
        public Service Update(Category record);
        public Service Delete(int id);
    }

    public class CategoryService : Service, ICategoryService
    {

        public CategoryService(Db db) : base(db)
        {

        }

        public Service Create (Category record)
        {
            //Way 1:
            //Category existingCategory = _db.Categories.SingleOrDefault(c => c.Name == record.Name);
            //if (existingCategory is not null)
            //{
            //    return Error("Category with the same name exists!");
            //    //Use methods with ...OrDefault in case th record is not found.
            //}

            //Way 2: an easier way
            if (_db.Categories.Any(c => c.Name.ToLower() == record.Name.ToLower().Trim()))
            {
                return Error("Category with the same name exists!");
            }

            //ToUpper ToLower ile case-sensitive kıyaslama yaptırabiliriz.
            //Örneğin databse'de Computer mevcut fakat computer ile kıyaslayıp tekrar yeni bir computer kategorisi ekleyebilir. Buun önüne geçmek için tolower ve toupper kullanabiliriz. Farklı yaım hatalarını manuel tespit etmek gerekiyor.
            //Boşlukları tespit etmek için Trim() kullanıyoruz.

            record.Name = record.Name?.Trim();
            record.Description = record.Description?.Trim();

            //If we try to trim null we get exception. There is nothing to trim.
            //If we are trimming strings it is preferred to use question mark.

            _db.Categories.Add(record);
            _db.SaveChanges();
            return Success("Category is created successfully.");
        }

        public Service Update(Category record) 
        {
            if (_db.Categories.Any(c => c.Id != record.Id && c.Name.ToUpper() == record.Name.ToUpper().Trim()))
            {
                return Error("\"Category with the same name exists!");
            }
            _db.Categories.Update(record);
            _db.SaveChanges();
            return Success("Category is created successfully.");
        }

        public Service Delete (int id)
        {
            //Category category = _db.Categories.Find(id);

            Category category = _db.Categories.Include(c=> c.Products).SingleOrDefault(c => c.Id == id);
            if (category is null)
            {
                return Error("Category is not found.");
            }

            //Way 1:
            //if (category.Products.Count > 0)
            //{
            //    return Error("Category has relational products!");
            //}

            //Way 2:
            if (category.Products.Any())
            {
                return Error("Category has relational products!");
            }

                _db.Categories.Remove(category);
            _db.SaveChanges();
            return Success("Category is deleted successfully.");
        }

        public IQueryable<CategoryModel> Query() {
            return _db.Categories.Select(c => new CategoryModel()
            {
                Record = c
            });
        }
    }

}

//Dependency injection
//Interface segregation
//We can't initialize abstract structures example: we can't initialize interfaces
//OOP'de base olarak new yapabiliyoruz daha sonra sub olarak 