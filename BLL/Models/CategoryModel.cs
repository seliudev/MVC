using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CategoryModel
    {
        public CategoryModel Record { get; set; }

        public string Name => Record.Name;

        //public string Name
        //{
        //    get
        //    {
        //        return Record.Name;
        //    }
        //}

        public string Description => Record.Description;   

    }
}
