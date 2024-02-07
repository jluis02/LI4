// WatchRepository.cs
namespace DataLayer.Watches;

public class WatchRepository : IWatchRepository
{
    private readonly ISqlDataAccess _db;

    public WatchRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<WatchModel>> GetAllClocksAsync()
    {
        string sql = "SELECT * FROM watches";
        return await _db.LoadData<WatchModel, dynamic>(sql, new { });
    }

    public async Task<int> AddClockAsync(WatchModel watch)
    {
        string sql = "INSERT INTO watches (Modelo, NumeroSerie, Descricao, Imagem, Marca, EstadoConservacao, TemCaixaOriginal, AnoFabrico, RelogioFunciona, PrecoBase) " +
                     "OUTPUT INSERTED.Id " + 
                     "VALUES (@Modelo, @NumeroSerie, @Descricao, @Imagem, @Marca, @EstadoConservacao, @TemCaixaOriginal, @AnoFabrico, @RelogioFunciona, @PrecoBase)";

        return await _db.SaveDataGetId(sql, new
        {
            watch.Modelo,
            watch.NumeroSerie,
            watch.Descricao,
            watch.Imagem,
            watch.Marca,
            watch.EstadoConservacao,
            watch.TemCaixaOriginal,
            watch.AnoFabrico,
            watch.RelogioFunciona,
            watch.PrecoBase
        });
    }
}