namespace AirGuard.Dominio;

public class Leitura
{
    public string PontoId { get; }
    public DateTimeOffset TimestampOrigem { get; }
    public double Valor { get; }
    public string Unidade { get; } 
    
    public Leitura(string pontoId, DateTimeOffset timestampOrigem, double valor, string unidade)
    {
        PontoId = pontoId;
        TimestampOrigem = timestampOrigem;
        Valor = valor;
        Unidade = unidade;
    }
}
