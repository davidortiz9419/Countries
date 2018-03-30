namespace Countries.Domain
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Countries.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<Countries.Domain.UserType> UserTypes { get; set; }
    }
}