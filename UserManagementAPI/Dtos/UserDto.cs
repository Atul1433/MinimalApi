using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Dtos;

public class UserDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Email must be a valid format.")]
    public string Email { get; set; } = default!;
}
