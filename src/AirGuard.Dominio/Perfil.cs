namespace AirGuard.Dominio;

public class Perfil
{
    private readonly List<VersaoDoPerfil> _versoes;

    public Perfil(List<VersaoDoPerfil> versoes)
    {
        _versoes = new List<VersaoDoPerfil>(versoes);
    }

    public VersaoDoPerfil? VersaoVigenteEm(DateTimeOffset momento)
    {
        VersaoDoPerfil? vigente = null;

        foreach (var versao in _versoes)
        {
            if (versao.InicioVigencia <= momento
                && (vigente is null || versao.InicioVigencia > vigente.InicioVigencia))
            {
                vigente = versao;
            }
        }

        return vigente;
    }

    public Conformidade Avaliar(Leitura leitura)
    {
        var versao = VersaoVigenteEm(leitura.TimestampOrigem);
        if (versao is null)
        {
            return Conformidade.SemRegra;
        }

        var faixa = versao.FaixaPara(leitura.Unidade);
        if (faixa is null)
        {
            return Conformidade.SemRegra;
        }

        if (faixa.Contem(leitura.Valor))
        {
            return Conformidade.Conforme;
        }

        return Conformidade.NaoConforme;
    }
}
