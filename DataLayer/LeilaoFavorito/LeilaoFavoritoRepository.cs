namespace DataLayer.LeilaoFavorito;

public class LeilaoFavoritoRepository : ILeilaoFavoritoRepository
{
    private ISqlDataAccess _db;
    public LeilaoFavoritoRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<LeilaoFavoritoModel> Find(int id)
    {
        Console.WriteLine($"Entrei em Find Utilizador Movel com username: {id}!");
        string sql = $"select * from Utilizador where username = '{id}'";
        List<LeilaoFavoritoModel> leiRes = await _db.LoadData<LeilaoFavoritoModel, dynamic>(sql, new { Id = id });
        Console.WriteLine("depois de _db.LoadData");
        if (leiRes != null && leiRes.Count > 0)
        {
            Console.WriteLine($"Encontrei {leiRes.Count}");
            return leiRes.First();
        }
        else
        {
            Console.WriteLine("Utilizador encontrou null");
            return null;
        }
    }

    public Task<List<LeilaoFavoritoModel>> FindAll()
    {
        string sql = "select * from LeilaoFavorito";
        return _db.LoadData<LeilaoFavoritoModel, dynamic>(sql, new { });
    }

    public async Task Create(LeilaoFavoritoModel lei)
    {
        string sql = "INSERT INTO LeilaoFavorito (Utilizador_idUtilizador, Leilao_idLeilao)" +
                     "VALUES (@Utilizador_idUtilizador, @Leilao_idLeilao)";

        await _db.SaveData(sql, new
        {
            lei.Utilizador_idUtilizador,
            lei.Leilao_idLeilao
        });
    }

    public Task<LeilaoFavoritoModel> Update(LeilaoFavoritoModel user)
    {
        //string sql = "UPDATE Utilizador SET ";
        throw new NotImplementedException();
    }

    public Task Remove(int code)
    {
        throw new NotImplementedException();
    }
}