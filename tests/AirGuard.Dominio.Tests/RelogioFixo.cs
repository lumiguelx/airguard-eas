namespace AirGuard.Dominio.Tests;

public class RelogioFixo : TimeProvider
{
    private readonly DateTimeOffset _agora;
    public RelogioFixo(DateTimeOffset agora)
    {
        _agora = agora;
    }

    public override DateTimeOffset GetUtcNow()
    {
        return _agora;
    }
}
