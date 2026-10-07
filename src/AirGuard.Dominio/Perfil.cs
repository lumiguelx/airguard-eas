namespace AirGuard.Dominio;

public class Perfil
{
    private readonly List<VersaoDoPerfil> _versoes;

    public Perfil(List<VersaoDoPerfil> versoes)
    {
        _versoes = versoes;
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
}
