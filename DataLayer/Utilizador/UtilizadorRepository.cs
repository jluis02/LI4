using DataLayer.Leilao;

namespace DataLayer.Utilizador;

public class UtilizadorRepository : IUtilizadorRepository
{
    private ISqlDataAccess _db;
    public UtilizadorRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<UtilizadorModel> Find(string username)
    {
        Console.WriteLine($"Entrei em Find Utilizador Movel com username: {username}!");
        string sql = $"select * from Utilizador where username = '{username}'";
        List<UtilizadorModel> utiRes = await _db.LoadData<UtilizadorModel, dynamic>(sql, new { Username = username });
        Console.WriteLine("depois de _db.LoadData");
        if (utiRes != null && utiRes.Count > 0)
        {
            Console.WriteLine($"Encontrei {utiRes.Count}");
            return utiRes.First();
        }
        else
        {
            Console.WriteLine("Utilizador encontrou null");
            return null;
        }
    }

    public async Task<UtilizadorModel> FindId(int id)
    {
        string sql = $"select * from Utilizador where idUtilizador = @id";
        List<UtilizadorModel> utiRes = await _db.LoadData<UtilizadorModel, dynamic>(sql, new { id });
        if (utiRes != null && utiRes.Count > 0)
        {
            return utiRes.First();
        }
        else
        {
            Console.WriteLine("Utilizador encontrou null");
            return null;
        }
    }

    public Task<List<UtilizadorModel>> FindAll()
    {
        string sql = "select * from Utilizador";
        return _db.LoadData<UtilizadorModel, dynamic>(sql, new { });
    }

    public async Task Create(UtilizadorModel user)
    {
        string sql = "INSERT INTO Utilizador (username, email, password, avaliacaoMedia, numeroDeLeiloesFeitos, imagem,dataDeRegisto)" +
                     "VALUES (@username, @email, @password, @avaliacaoMedia, @numeroDeLeiloesFeitos, @Imagem,@dataDeRegisto)";

        await _db.SaveData(sql, new
        {
            user.username,
            user.email,
            user.password,
            user.avaliacaoMedia,
            user.numeroDeLeiloesFeitos,
            user.Imagem,
            user.dataDeRegisto
        });
    }

    public async Task<UtilizadorModel> UpdateNumLeilao(string user, int numLeilao)
    {
        try
        {
            string sql = "UPDATE utilizador SET NumeroDeLeiloesFeitos = @nLeilao WHERE username = @userA";

            await _db.SaveData(sql, new
            {
                nLeilao = numLeilao,
                userA = user
            });

            return await Find(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating NumeroDeLeiloesFeiros for Utilizador: {ex.Message}");
            throw;
        }
    }

    public async Task<UtilizadorModel> UpdateAvaliacaoMedia(string user, int avaliacao)
{
    try
    {
        var utilizador = await Find(user);

        string sql = "UPDATE utilizador SET AvaliacaoMedia = @novaAvaliacaoMedia WHERE username = @userA";

        await _db.SaveData(sql, new
        {
            novaAvaliacaoMedia = utilizador.avaliacaoMedia + avaliacao,
            userA = user
        });

        return await Find(user);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error updating AvaliacaoMedia for Utilizador");
        throw;
    }
}

    public Task<UtilizadorModel> Update(UtilizadorModel user)
    {
        //string sql = "UPDATE Utilizador SET ";
        throw new NotImplementedException();
    }

    public Task Remove(int code)
    {
        throw new NotImplementedException();
    }
}