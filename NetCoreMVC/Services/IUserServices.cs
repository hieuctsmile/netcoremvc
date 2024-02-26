using NetCoreMVC.Models.Entities;

namespace NetCoreMVC.Services;

public interface IUserServices
{
    public Task CreateAsync(User user);
    public Task<User> GetAsync(string id);
    public Task<List<User>> GetAsync();
    public Task UpdateAsync(string id, User user);
    public Task RemoveAsync(string id);
}
