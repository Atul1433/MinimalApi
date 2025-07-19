using UserManagementAPI.Models;

namespace UserManagementAPI.Services;

public interface IUserService
{
    List<User> GetAll();
    User? GetById(int id);
    void Add(User user);
    bool Update(int id, User updatedUser);
    bool Delete(int id);
}
