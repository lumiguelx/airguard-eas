namespace AirGuard.Dominio;

public class DetectorDeExcursao
{
    private readonly TimeSpan _tolerancia;
    private DateTimeOffset? _foraDesde;

    public DetectorDeExcursao(TimeSpan tolerancia)
    {
        _tolerancia = tolerancia;
    }

    public bool EmExcursao { get; private set; }
    public DateTimeOffset? InicioDaExcursao { get; private set; }

    public void Registrar(DateTimeOffset momento, Conformidade conformidade)
    {
        if (conformidade == Conformidade.Conforme)
        {
            _foraDesde = null;
            EmExcursao = false;
            return;
        }

        if (_foraDesde is null)
        {
            _foraDesde = momento;
        }

        if (!EmExcursao && momento - _foraDesde > _tolerancia)
        {
            EmExcursao = true;
            InicioDaExcursao = momento;
        }
    }
}
