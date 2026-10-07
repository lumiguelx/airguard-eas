namespace AirGuard.Dominio.Tests;

public class PerfilTests
{
    [Fact]
    public void VersaoVigenteEm_DataAntesDaSegundaVersao_RetornaAPrimeira()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var v2 = new VersaoDoPerfil(2, new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var perfil = new Perfil(new List<VersaoDoPerfil> { v1, v2 });

        var fevereiro = new DateTimeOffset(2026, 2, 15, 0, 0, 0, TimeSpan.Zero);

        Assert.Same(v1, perfil.VersaoVigenteEm(fevereiro));
    }

    [Fact]
    public void VersaoVigenteEm_DataDepoisDaSegundaVersao_RetornaASegunda()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var v2 = new VersaoDoPerfil(2, new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var perfil = new Perfil(new List<VersaoDoPerfil> { v1, v2 });

        var marco = new DateTimeOffset(2026, 3, 10, 0, 0, 0, TimeSpan.Zero);

        Assert.Same(v2, perfil.VersaoVigenteEm(marco));
    }

    [Fact]
    public void VersaoVigenteEm_ListaForaDeOrdem_RetornaAVersaoDaEpoca()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var v2 = new VersaoDoPerfil(2, new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var perfil = new Perfil(new List<VersaoDoPerfil> { v2, v1 });

        var marco = new DateTimeOffset(2026, 3, 10, 0, 0, 0, TimeSpan.Zero);

        Assert.Same(v2, perfil.VersaoVigenteEm(marco));
    }
}
