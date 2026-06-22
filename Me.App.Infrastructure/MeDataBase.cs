using SQLite;
using Me.App.Core.DocumentsAgg;
using Me.App.Core.Security;
using Me.App.Core.UserAgg;

namespace Me.App.Infrastructure;

public class MeDataBase
{
    private SQLiteAsyncConnection? _db;
    private readonly IDatabaseKeyProvider _keyProvider;
    private readonly string _dbPath;

    public MeDataBase(IDatabaseKeyProvider keyProvider, string dbPath)
    {
        _keyProvider = keyProvider;
        _dbPath = dbPath;
    }
    public async Task<SQLiteAsyncConnection> GetConnectionAsync()
    {
        if (_db != null) return _db;

        var dbKey = await _keyProvider.GetOrGenerateKeyAsync();

        var options = new SQLiteConnectionString(_dbPath, true, key: dbKey);
        _db = new SQLiteAsyncConnection(options);


        await _db.CreateTableAsync<User>();
        await _db.CreateTableAsync<Document>();
        await _db.CreateTableAsync<Blob>();

        return _db;
    }
}