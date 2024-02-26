using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NetCoreMVC.Models.Entities;

namespace NetCoreMVC.Services;

public class UserServices : IUserServices
{
    private readonly IMongoCollection<User> _users;

    public UserServices(IOptions<DbSettings> dbSettings)
    {
        var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

        _users = mongoDatabase.GetCollection<User>(dbSettings.Value.UsersCollection);
    }
    public async Task<List<User>> GetAsync() => await _users.Find(_ => true).ToListAsync();

    public async Task<User> GetAsync(string id) => await _users.Find(x => x.UniqueId == id).FirstOrDefaultAsync();


    public async Task CreateAsync(User newUser) => await _users.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updateUser) => await _users.ReplaceOneAsync(x => x.UniqueId == id, updateUser);

    public async Task RemoveAsync(string id) => await _users.DeleteOneAsync(x => x.UniqueId == id);
}
