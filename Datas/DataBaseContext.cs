using Microsoft.EntityFrameworkCore;
using RestfullDemo.Models;

namespace RestfullDemo.Datas
{
    public class DataBaseContext : DbContext
    {
        //DbContext sınıfının constructurını cagırmak icin base() ifadesi
        public DataBaseContext(DbContextOptions<DataBaseContext> DbContextOption) : base(DbContextOption)
        {

        }

        public DbSet<UserRequestModel> ContextUser { get; set; }
    }
}
