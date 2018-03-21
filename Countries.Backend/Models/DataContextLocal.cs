namespace Countries.Backend.Models
{
    using Domain;

    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<Countries.Domain.User> Users { get; set; }
    }
}