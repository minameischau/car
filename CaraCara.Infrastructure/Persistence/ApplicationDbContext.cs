using CaraCara.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CaraCara.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    
    // Vehicle Management
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleBooking> VehicleBookings { get; set; }
    public DbSet<VehicleSale> VehicleSales { get; set; }

    // Service Workshop
    public DbSet<ServiceOrder> ServiceOrders { get; set; }
    public DbSet<ServiceDetail> ServiceDetails { get; set; }
    public DbSet<ServicePartUsage> ServicePartUsages { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }

    // Inventory
    public DbSet<Part> Parts { get; set; }
    public DbSet<PartStock> PartStocks { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<StockTransaction> StockTransactions { get; set; }

    // Customer & CRM
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerInteraction> CustomerInteractions { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<CampaignCustomer> CampaignCustomers { get; set; }

    // Accounting
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<AccountReceivable> AccountReceivables { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Rename Identity tables (remove Prefix "AspNet")
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName != null && tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }

        // Configure Employee relationship with ApplicationUser
        builder.Entity<ApplicationUser>()
            .HasOne(u => u.Employee)
            .WithOne(e => e.ApplicationUser)
            .HasForeignKey<ApplicationUser>(u => u.EmployeeId)
            .IsRequired(false);

        // Configure Employee self-relationship for Manager
        builder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(e => e.Subordinates)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Additional configuration for ApplicationRole (e.g. Description)
        builder.Entity<ApplicationRole>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // Prevent multiple cascade paths for ServiceOrder
        builder.Entity<ServiceOrder>()
            .HasOne(so => so.Customer)
            .WithMany(c => c.ServiceOrders)
            .HasForeignKey(so => so.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ServiceOrder>()
            .HasOne(so => so.Vehicle)
            .WithMany()
            .HasForeignKey(so => so.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Prevent multiple cascade paths for VehicleSale
        builder.Entity<VehicleSale>()
            .HasOne(vs => vs.Customer)
            .WithMany(c => c.Purchases)
            .HasForeignKey(vs => vs.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<VehicleSale>()
            .HasOne(vs => vs.Vehicle)
            .WithMany() // Assuming Vehicle doesn't need a collection of Sales
            .HasForeignKey(vs => vs.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Entity<VehicleSale>()
            .HasOne(vs => vs.Invoice)
            .WithOne() // 1-1 relationship likely, check Entity
            .HasForeignKey<VehicleSale>(vs => vs.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        // Prevent multiple cascade paths for Invoice
        builder.Entity<Invoice>()
            .HasOne(i => i.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // CampaignCustomer Composite Key
        builder.Entity<CampaignCustomer>()
            .HasKey(cc => new { cc.CampaignId, cc.CustomerId });

        // Decimal Precision Configuration
        var decimalProps = new[]
        {
            (typeof(Vehicle), "Price"),
            (typeof(VehicleBooking), "DepositAmount"),
            (typeof(VehicleSale), "SalePrice"),
            (typeof(ServiceOrder), "TotalCost"),
            (typeof(ServiceDetail), "LaborCost"),
            (typeof(ServiceType), "DefaultLaborCost"),
            (typeof(ServicePartUsage), "UnitPrice"),
            (typeof(Part), "PurchasePrice"),
            (typeof(Part), "SalePrice"),
            (typeof(Invoice), "TotalAmount"),
            (typeof(Payment), "Amount"),
            (typeof(AccountReceivable), "TotalDue"),
            (typeof(AccountReceivable), "TotalPaid"),
            (typeof(AccountReceivable), "Balance")
        };

        foreach (var (type, propName) in decimalProps)
        {
            builder.Entity(type).Property(propName).HasColumnType("decimal(18,2)");
        }
    }
}
