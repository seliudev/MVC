using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class Db : DbContext //inheritance
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } //for CRUD operations

        public Db(DbContextOptions<Db> options) : base(options) //base is DbContext
        {
            //inheritance aşamasında dbcontext'i yazıyoruz fakat constructor inherit ederken base kullanıyoruz yine aslında dbcontext olmuş oluyor.
        
        }

    }
}

//Ders sonunda ORM kullanmış olacağız
//Dapper id another alternative as ORM
//Hybernet in Java is another ORM
//Code first approach uyguluyoruz derste