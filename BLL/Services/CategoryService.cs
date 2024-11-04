using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : Service
    {
        public CategoryService(Db db) : base(db)
        {

        }

        public Service Create (Category record)
        {
            _db.Categories.Add(record);
            _db.SaveChanges();
        }

    }
}

//Dependency injection
