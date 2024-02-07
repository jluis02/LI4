namespace DataLayer.Licitacao;

public record LicitacaoModel
{
    public string? _Id { get; set; }
    public int Id { get; }
    public string username { get; set; } = "";
    public int valor { get; set; } = 0;
    public string Data { get; set; } = "";
    public int Leilao_idUtilizador { get; set; } = 0;
    public int Utilizador_idUtilizador { get; set; } = 0;
} 