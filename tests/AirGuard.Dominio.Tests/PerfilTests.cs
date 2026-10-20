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

    [Fact]
    public void VersaoVigenteEm_DataNoInicioDaSegundaVersao_RetornaASegunda()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var v2 = new VersaoDoPerfil(2, new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var perfil = new Perfil(new List<VersaoDoPerfil> { v1, v2 });

        var inicioDaV2 = new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero);

        Assert.Same(v2, perfil.VersaoVigenteEm(inicioDaV2));
    }

    [Fact]
    public void VersaoVigenteEm_DataAntesDaPrimeiraVersao_RetornaNulo()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var v2 = new VersaoDoPerfil(2, new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>());
        var perfil = new Perfil(new List<VersaoDoPerfil> { v1, v2 });

        var antesDaV1 = new DateTimeOffset(2025, 12, 15, 0, 0, 0, TimeSpan.Zero);

        Assert.Null(perfil.VersaoVigenteEm(antesDaV1));
    }

    [Fact]
    public void Avaliar_LeituraDentroDaFaixaDaVersaoVigente_RetornaConforme()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>
        {
            [Unidade.Celsius] = new Faixa(20.0, 24.0),
        });
        var perfil = new Perfil(new List<VersaoDoPerfil> { v1 });

        var leitura = new Leitura("UTI-01-TEMP", new DateTimeOffset(2026, 2, 15, 0, 0, 0, TimeSpan.Zero), 23.5, Unidade.Celsius);

        Assert.Equal(Conformidade.Conforme, perfil.Avaliar(leitura));
    }

    [Fact]
    public void Avaliar_TrocaDeVersaoNoMeioDaSerie_UsaVersaoDeCadaData()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>
        {
            [Unidade.Celsius] = new Faixa(20.0, 24.0),
        });
        var v2 = new VersaoDoPerfil(2, new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>
        {
            [Unidade.Celsius] = new Faixa(21.0, 23.0),
        });
        var perfil = new Perfil(new List<VersaoDoPerfil> { v1, v2 });

        var fevereiro = new Leitura("UTI-01-TEMP", new DateTimeOffset(2026, 2, 15, 0, 0, 0, TimeSpan.Zero), 23.5, Unidade.Celsius);
        var marco = new Leitura("UTI-01-TEMP", new DateTimeOffset(2026, 3, 10, 0, 0, 0, TimeSpan.Zero), 23.5, Unidade.Celsius);

        Assert.Equal(Conformidade.Conforme, perfil.Avaliar(fevereiro));
        Assert.Equal(Conformidade.NaoConforme, perfil.Avaliar(marco));
    }

    [Fact]
    public void Avaliar_LeituraAntesDaPrimeiraVersao_RetornaSemRegra()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>
        {
            [Unidade.Celsius] = new Faixa(20.0, 24.0),
        });
        var perfil = new Perfil(new List<VersaoDoPerfil> { v1 });

        var leitura = new Leitura("UTI-01-TEMP", new DateTimeOffset(2025, 12, 15, 0, 0, 0, TimeSpan.Zero), 23.5, Unidade.Celsius);

        Assert.Equal(Conformidade.SemRegra, perfil.Avaliar(leitura));
    }

    [Fact]
    public void Avaliar_UnidadeSemFaixaNaVersao_RetornaSemRegra()
    {
        var v1 = new VersaoDoPerfil(1, new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero), new Dictionary<Unidade, Faixa>
        {
            [Unidade.Celsius] = new Faixa(20.0, 24.0),
        });
        var perfil = new Perfil(new List<VersaoDoPerfil> { v1 });

        var leitura = new Leitura("UTI-01-CO2", new DateTimeOffset(2026, 2, 15, 0, 0, 0, TimeSpan.Zero), 800.0, Unidade.Ppm);

        Assert.Equal(Conformidade.SemRegra, perfil.Avaliar(leitura));
    }
}
