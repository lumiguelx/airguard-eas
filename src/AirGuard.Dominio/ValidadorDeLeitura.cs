namespace AirGuard.Dominio;

public class ValidadorDeLeitura
{
    private readonly TimeProvider _relogio;
    public ValidadorDeLeitura(TimeProvider relogio)
    {
        _relogio = relogio;
    }
    public void Validar(Leitura leitura)
    {
        if (leitura.TimestampOrigem > _relogio.GetUtcNow())
        {
            throw new ArgumentOutOfRangeException(nameof(leitura), "TimestampOrigem no futuro.");
        }
    }
}

