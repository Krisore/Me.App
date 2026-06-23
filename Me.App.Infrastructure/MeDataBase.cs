using Me.App.Core.DocumentsAgg;
using Me.App.Core.Security;
using Me.App.Core.UserAgg;
using Me.App.Core.VehicleAggregate;
using SQLite;

namespace Me.App.Infrastructure;

public class MeDataBase(IDatabaseKeyProvider keyProvider, string dbPath)
{
    private SQLiteAsyncConnection? _db;
    private readonly IDatabaseKeyProvider _keyProvider = keyProvider;
    private readonly string _dbPath = dbPath;

    public async Task<SQLiteAsyncConnection> GetConnectionAsync()
    {
        if (_db != null) return _db;

        var dbKey = await _keyProvider.GetOrGenerateKeyAsync();

        var options = new SQLiteConnectionString(_dbPath, true, key: dbKey);
        _db = new SQLiteAsyncConnection(options);


        await _db.CreateTableAsync<User>();
        await _db.CreateTableAsync<Document>();
        await _db.CreateTableAsync<Blob>();
        await _db.CreateTableAsync<Vehicle>();
        await _db.CreateTableAsync<MaintenanceTask>();

        return _db;
    }
}