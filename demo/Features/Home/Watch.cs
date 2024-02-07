namespace demo.Features.Home;
public class Watch
{
    public int Id { get; set; }
    public string Modelo { get; set; } = "";
    public string NumeroSerie { get; set; } = "";
    public string Descricao { get; set; } = "";
    public byte[] Imagem { get; set; }
    public string Marca { get; set; } = "";
    public string EstadoConservacao { get; set; } = "";
    public bool TemCaixaOriginal { get; set; }
    public int AnoFabrico { get; set; }
    public bool RelogioFunciona { get; set; }
    public double PrecoBase { get; set; }
}

