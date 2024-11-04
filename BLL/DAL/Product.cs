using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        //Relational database ex: there is s relation between Category and Product
        public int Id { get; set; } // PK, this is required since we didnt use question mark so its required automatically thats why we dont have to use required here
        [Required] //Database applications, we will use requşred for strings mostly
        [StringLength(150)]
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int CategoryId { get; set; } // FK
        public int? StockAmount { get; set; } //Nullable value type using ? 
        public Category Category { get; set; }
    }
}
