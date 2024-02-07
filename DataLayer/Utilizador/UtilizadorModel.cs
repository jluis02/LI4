namespace DataLayer.Utilizador;

public record UtilizadorModel
{
    public int idUtilizador { get; set; } = 0;
    public string username { get; set; } = "";
    public string email { get; set; } = "";
    public string password { get; set; } = "";
    public float avaliacaoMedia { get; set; } = 0;
    public int numeroDeLeiloesFeitos { get; set; }
    public byte[] Imagem { get; set; }
    public string dataDeRegisto { get; set; } = "";
}