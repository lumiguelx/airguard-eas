namespace AirGuard.Dominio.Tests;

public class FaixaTests
{
    [Theory]
    [InlineData(20.0)]
    [InlineData(22.0)]
    [InlineData(24.0)]
    public void Contem_ValorDentroDaFaixa_RetornaTrue(double valor)
    {
        var faixa = new Faixa(20.0, 24.0);

        Assert.True(faixa.Contem(valor));
    }

    [Theory]
    [InlineData(19.9)]
    [InlineData(24.1)]
    public void Contem_ValorForaDaFaixa_RetornaFalse(double valor)
    {
        var faixa = new Faixa(20.0, 24.0);

        Assert.False(faixa.Contem(valor));
    }

    [Theory]
    [InlineData(5.0)]
    [InlineData(1000.0)]
    public void Contem_FaixaSemMaximo_AceitaValorAcimaDoMinimo(double valor)
    {
        var faixa = new Faixa(5.0, null);

        Assert.True(faixa.Contem(valor));
    }

    [Fact]
    public void Contem_FaixaSemMaximo_RejeitaValorAbaixoDoMinimo()
    {
        var faixa = new Faixa(5.0, null);

        Assert.False(faixa.Contem(4.9));
    }

    [Theory]
    [InlineData(60.0)]
    [InlineData(-1000.0)]
    public void Contem_FaixaSemMinimo_AceitaValorAbaixoDoMaximo(double valor)
    {
        var faixa = new Faixa(null, 60.0);

        Assert.True(faixa.Contem(valor));
    }

    [Fact]
    public void Contem_FaixaSemMinimo_RejeitaValorAcimaDoMaximo()
    {
        var faixa = new Faixa(null, 60.0);

        Assert.False(faixa.Contem(60.1));
    }
}
