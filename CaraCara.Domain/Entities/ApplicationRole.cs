using Microsoft.AspNetCore.Identity;

namespace CaraCara.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }
}
