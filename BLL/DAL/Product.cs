using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable 

namespace BLL.DAL
{
    public class Product
    {
        //private int id;

        //public void SetId()
        //{
        //    this.id = id;
        //}

        //public int GetId() 
        //{ 
        //    return this.id;
        //}

        public int Id { get; set; } // PK
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int CategoryId { get; set; } // FK
        public int? StockAmount { get; set; } //Nullable value type using ? 
        public Category Category { get; set; }
    }
}
