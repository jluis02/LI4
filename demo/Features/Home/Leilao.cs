namespace demo.Features.Home;

public class Leilao
{
    public int Id { get; }
    public int Relogio_id { get; set; } = 0;
    public string DataInicio { get; set; } = "";
    public string DataFim { get; set; } = "";
    public int LicitacaoAtual { get; set; } = 0;
    public int Utilizador_idUtilizador { get; set; } = 0;
}
