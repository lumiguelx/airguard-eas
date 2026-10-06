namespace AirGuard.Dominio.Tests;

public class VersaoDoPerfilTests
{
    [Fact]
    public void FaixaPara_UnidadeCadastrada_RetornaAFaixa()
    {
        var temperatura = new Faixa(20.0, 24.0);
        var faixas = new Dictionary<Unidade, Faixa>
        {
            [Unidade.Celsius] = temperatura,
        };
        var inicio = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var versao = new VersaoDoPerfil(1, inicio, faixas);

        Assert.Same(temperatura, versao.FaixaPara(Unidade.Celsius));
    }

    [Fact]
    public void FaixaPara_UnidadeNaoCadastrada_RetornaNull()
    {
        var faixas = new Dictionary<Unidade, Faixa>
        {
            [Unidade.Celsius] = new Faixa(20.0, 24.0),
        };
        var inicio = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var versao = new VersaoDoPerfil(1, inicio, faixas);

        Assert.Null(versao.FaixaPara(Unidade.Ppm));
    }
}
