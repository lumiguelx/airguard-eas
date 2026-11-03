namespace AirGuard.Dominio;

public class DetectorDeExcursao
{
    private readonly TimeSpan _tolerancia;
    private DateTimeOffset? _foraDesde;
    private DateTimeOffset? _ultimoMomento;

    public DetectorDeExcursao(TimeSpan tolerancia)
    {
        if (tolerancia <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(tolerancia));
        }

        _tolerancia = tolerancia;
    }

    public bool EmExcursao { get; private set; }
    public DateTimeOffset? InicioDaExcursao { get; private set; }
    public DateTimeOffset? FimDaExcursao { get; private set; }

    public void Registrar(DateTimeOffset momento, Conformidade conformidade)
    {
        if (conformidade == Conformidade.SemRegra)
        {
            return;
        }

        if (momento < _ultimoMomento)
        {
            return;
        }

        _ultimoMomento = momento;

        if (conformidade == Conformidade.Conforme)
        {
            _foraDesde = null;
            if (EmExcursao)
            {
                FimDaExcursao = momento;
            }
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
