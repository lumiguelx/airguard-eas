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
}
