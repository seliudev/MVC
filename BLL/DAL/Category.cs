using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required] //Aspect oriented programming
        [StringLength(100)]
        public string Description { get; set; }
        public List<Product> Products { get; set; } //array but we will name it collection
        //one to many relation in database which is "one category can have many products"
    }
}
//Aslında SOLID S-Single responsibility özelliğini validation yapmaya çalıştığımız için [Required] kısmında ezmiş oluyoruz fakat o kadar da abartmaya gerek yokmuş :)
//code first approach: we create our entities then database is created from them.
