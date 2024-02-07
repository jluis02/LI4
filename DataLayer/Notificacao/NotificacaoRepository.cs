namespace DataLayer.Notificacao;

public class NotificacaoRepository : INotificacaoRepository
{
    private ISqlDataAccess _db;
    public NotificacaoRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<NotificacaoModel> Find(int idNotificacao)
    {
        Console.WriteLine($"Entrei em Find Licitacao Movel com username: {idNotificacao}!");
        string sql = $"select * from Notificacao where id = '{idNotificacao}'";
        List<NotificacaoModel> leiRes = await _db.LoadData<NotificacaoModel, dynamic>(sql, new { id = idNotificacao });
        Console.WriteLine("depois de _db.LoadData");
        if (leiRes != null && leiRes.Count > 0)
        {
            Console.WriteLine($"Encontrei {leiRes.Count}");
            return leiRes.First();
        }
        else
        {
            Console.WriteLine("Licitacao encontrou null");
            return null;
        }
    }

    public Task<List<NotificacaoModel>> FindAllFromUtilizador(int idUser)
    {
        string sql = $"select * from Notificacao Where Utilizador_idUtilizador = {idUser}";
        return _db.LoadData<NotificacaoModel, dynamic>(sql, new { Utilizador_idUtilizador = idUser });
    }

    public async Task Create(NotificacaoModel noti)
    {
        string sql = "INSERT INTO Notificacao (Tipo, Utilizador_idUtilizador, Leilao_idLeilao)" +
                     "VALUES (@Tipo, @Utilizador_idUtilizador, @Leilao_idLeilao)";

        await _db.SaveData(sql, new
        {
            noti.Tipo,
            noti.Utilizador_idUtilizador,
            noti.Leilao_idLeilao
        });
    }

    public Task<NotificacaoModel> Update(NotificacaoModel licitacao)
    {
        //string sql = "UPDATE Utilizador SET ";
        throw new NotImplementedException();
    }

    public async Task Remove(int id)
    {
        string sql = "DELETE FROM Notificacao WHERE id = @Id";
        await _db.SaveData(sql, new { Id = id });
    }

   
}