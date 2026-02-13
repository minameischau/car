using Microsoft.AspNetCore.Identity;

namespace CaraCara.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public int? EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
}
