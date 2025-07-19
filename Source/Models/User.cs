using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = default!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;
}
