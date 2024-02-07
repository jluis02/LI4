namespace DataLayer.LeilaoFavorito;

public record LeilaoFavoritoModel
{
    public string? _Id { get; set; }
    public int Id { get; }
    public int Utilizador_idUtilizador { get; set; } = 0;
    public int Leilao_idLeilao { get; set; } = 0;
}