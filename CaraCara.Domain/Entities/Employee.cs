namespace CaraCara.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime HireDate { get; set; }
    public string? Status { get; set; }
    public int? ManagerId { get; set; }
    public virtual Employee? Manager { get; set; }
    public virtual ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
    
    // Identity link
    public virtual ApplicationUser? ApplicationUser { get; set; }
}
