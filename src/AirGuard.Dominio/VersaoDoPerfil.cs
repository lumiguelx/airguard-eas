namespace AirGuard.Dominio;

public class VersaoDoPerfil
{
    private readonly Dictionary<Unidade, Faixa> _faixas;

    public int Numero { get; }
    public DateTimeOffset InicioVigencia { get; }

    public VersaoDoPerfil(int numero, DateTimeOffset inicioVigencia, Dictionary<Unidade, Faixa> faixas)
    {
        Numero = numero;
        InicioVigencia = inicioVigencia;
        _faixas = faixas;
    }

    public Faixa? FaixaPara(Unidade unidade)
    {
        return _faixas.GetValueOrDefault(unidade);
    }
}
