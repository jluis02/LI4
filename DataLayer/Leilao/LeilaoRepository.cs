using static System.Net.Mime.MediaTypeNames;

using DataLayer.Watches;
using DataLayer.Utilizador;

namespace DataLayer.Leilao;

public class LeilaoRepository : ILeilaoRepository
{
    private ISqlDataAccess _db;
    public LeilaoRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    // POR ALTERAR 
    public async Task<LeilaoModel> Find(int leilaoId)
    {
        Console.WriteLine($"Entrei em Find Leilao Movel com username: {leilaoId}!");
        string sql = $"select * from Leilao where id = '{leilaoId}'";
        List<LeilaoModel> utiRes = await _db.LoadData<LeilaoModel, dynamic>(sql, new { id = leilaoId });
        Console.WriteLine("depois de _db.LoadData");
        if (utiRes != null && utiRes.Count > 0)
        {
            Console.WriteLine($"Encontrei {utiRes.Count}");
            return utiRes.First();
        }
        else
        {
            Console.WriteLine("Leilao encontrou null");
            return null;
        }
    }

    public async Task<bool> DeleteLeilao(int leilaoId)
    {
        LeilaoModel existingLeilao = await Find(leilaoId);

        if (existingLeilao == null)
        {
            Console.WriteLine($"Leilao com id {leilaoId} não encontrado.");
            return false;
        }

        try
        {
            string sql = $"DELETE FROM Leilao WHERE id = '{leilaoId}'";
            await _db.SaveData(sql, new { id = leilaoId });
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar Leilao com id {leilaoId}: {ex.Message}");
            return false;
        }
    }

    public async Task<WatchModel> FindWatch(int leilaoId)
    {
        string sql = $"SELECT w.* FROM Leilao l INNER JOIN watches w ON l.Relogio_id = w.id WHERE l.id = {leilaoId};";
        List<WatchModel> watches = await _db.LoadData<WatchModel, dynamic>(sql, new { Leilao = leilaoId });

        WatchModel watch = watches.FirstOrDefault();  // Pega o primeiro item da lista (ou retorna null se a lista estiver vazia)

        if(watch != null)
        {
            return watch;
        } else 
            return null;
    }

    public async Task<UtilizadorModel> FindUser(int leilaoId)
    {
        string sql = $"SELECT u.* FROM Leilao l INNER JOIN Utilizador u ON l.Utilizador_idUtilizador = u.idUtilizador WHERE l.id = {leilaoId};";
        List<UtilizadorModel> users = await _db.LoadData<UtilizadorModel, dynamic>(sql, new { Leilao = leilaoId });

        UtilizadorModel user = users.FirstOrDefault();  // Pega o primeiro item da lista (ou retorna null se a lista estiver vazia)

        if (user != null)
        {
            return user;
        }
        else
            return null;
    }

    public async Task<List<LeilaoModel>> FindLeilaoFav(int utilizadorId)
    {
        string sql = @"SELECT l.*
                   FROM LeilaoFavorito lf
                   INNER JOIN Leilao l ON lf.Leilao_idLeilao = l.id
                   WHERE lf.Utilizador_idUtilizador = @UtilizadorId;";

        List<LeilaoModel> leiloesFavoritos = await _db.LoadData<LeilaoModel, dynamic>(sql, new { UtilizadorId = utilizadorId });

        return leiloesFavoritos;
    }


    public Task<List<LeilaoModel>> FindAll()
    {
        string sql = "select * from Leilao";
        return _db.LoadData<LeilaoModel, dynamic>(sql, new { });
    }

    public Task<List<LeilaoModel>> FindLeiloesUtilizador(int idUtilizador)
    {
        string sql = $"select * from Leilao Where Utilizador_idUtilizador = {idUtilizador};";
        return _db.LoadData<LeilaoModel, dynamic>(sql, new { });
    }

    public async Task<int> Create(LeilaoModel leilao)
    {
        string sql = "INSERT INTO Leilao (Relogio_id, DataInicio, DataFim, LicitacaoAtual, Utilizador_idUtilizador)" +
                     "OUTPUT INSERTED.Id " +
                     "VALUES (@Relogio_id, @DataInicio, @DataFim, @LicitacaoAtual, @Utilizador_idUtilizador)";

        return await _db.SaveDataGetId(sql, new
        {
            leilao.Relogio_id,
            leilao.DataInicio,
            leilao.DataFim,
            leilao.LicitacaoAtual,
            leilao.Utilizador_idUtilizador
        });
    }

    public async Task<LeilaoModel> UpdateLicitacaoAtual(int leilaoId, int newLicitacaoAtual)
    {
        try
        {
            string sql = "UPDATE Leilao SET LicitacaoAtual = @NewLicitacaoAtual WHERE Id = @LeilaoId";

            await _db.SaveData(sql, new
            {
                NewLicitacaoAtual = newLicitacaoAtual,
                LeilaoId = leilaoId
            });

            // Retrieve the updated LeilaoModel
            return await Find(leilaoId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating LicitacaoAtual for Leilao: {ex.Message}");
            throw;
        }
    }

    public Task Remove(int code)
    {
        throw new NotImplementedException();
    }
}