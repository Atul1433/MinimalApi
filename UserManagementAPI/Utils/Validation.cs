using UserManagementAPI.Models;

namespace UserManagementAPI.Utils;

public static class Validation
{
    public static bool IsValidUser(User user) =>
        !string.IsNullOrWhiteSpace(user.Name) &&
        !string.IsNullOrWhiteSpace(user.Email) &&
        user.Email.Contains("@");
}
