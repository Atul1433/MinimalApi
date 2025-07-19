using UserManagementAPI.Models;

namespace UserManagementAPI.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = [];
    private int _nextId = 1;

    public List<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public void Add(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
    }

    public bool Update(int id, User updatedUser)
    {
        var user = GetById(id);
        if (user == null) return false;
        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        return true;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);
        if (user == null) return false;
        _users.Remove(user);
        return true;
    }
}
