namespace BLL.DAL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; } //array but we will name it collection
        //one to many relation in database which is "one category can have many products"
    }
}

//code first approach: we create our entities then database is created from them.