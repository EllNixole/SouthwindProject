using Microsoft.EntityFrameworkCore;


namespace EF_ModelFirst;


<<<<<<< HEAD
    

=======
>>>>>>> da0ad96f0d0cf742076b8985a2a875247202e6c0
public partial class SouthwindContext : DbContext
{
    public static SouthwindContext Instance { get; } = new SouthwindContext();


    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
<<<<<<< HEAD

=======
>>>>>>> da0ad96f0d0cf742076b8985a2a875247202e6c0
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Southwind;");
        }
    }
}

