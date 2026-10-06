namespace AirGuard.Dominio;

public class Leitura
{
    public string PontoId { get; }
    public DateTimeOffset TimestampOrigem { get; }
    public double Valor { get; }
    public Unidade Unidade { get; } 
    
    public Leitura(string pontoId, DateTimeOffset timestampOrigem, double valor, Unidade unidade)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(pontoId);
        if (!Enum.IsDefined(unidade))
        {
            throw new ArgumentOutOfRangeException(nameof(unidade));
        }

        PontoId = pontoId;
        TimestampOrigem = timestampOrigem;
        Valor = valor;
        Unidade = unidade;
    }
}
