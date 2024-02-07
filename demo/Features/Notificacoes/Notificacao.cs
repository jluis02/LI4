namespace demo.Features.Notificacoes;

public record Notificacao
{
    public int Id { get; }
    public string Tipo { get; set; } = "";
    public int Utilizador_idUtilizador { get; set; } = 0;
    public int Leilao_idLeilao { get; set; } = 0;
}