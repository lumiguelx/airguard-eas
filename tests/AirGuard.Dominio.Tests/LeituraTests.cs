namespace AirGuard.Dominio.Tests;

public class LeituraTests
{
    [Fact]
    public void Construtor_GuardaOsDadosInformados()
    {
        //Arrange
        var momento = new DateTimeOffset(2026, 10, 5, 14, 3, 0, TimeSpan.FromHours(-3));

        //Act
        var leitura = new Leitura("UTI-01-PRESSAO", momento, 2.5, Unidade.Pascal);

        //Assert
        Assert.Equal("UTI-01-PRESSAO", leitura.PontoId);
        Assert.Equal(momento, leitura.TimestampOrigem);
        Assert.Equal(2.5, leitura.Valor);
        Assert.Equal(Unidade.Pascal, leitura.Unidade);
    }

    [Fact]
    public void Construtor_RejeitaPontoIdVazio()
    {
        var momento = new DateTimeOffset(2026, 10, 5, 14, 3, 0, TimeSpan.FromHours(-3));
        Assert.Throws<ArgumentException>(() => new Leitura("", momento, 2.5, Unidade.Pascal));
    }
    [Fact]
    public void Construtor_RejeitaUnidadeForaDaLista()
    {
        var momento = new DateTimeOffset(2026, 10, 5, 14, 3, 0, TimeSpan.FromHours(-3));

        Assert.Throws<ArgumentOutOfRangeException>(() => new Leitura("UTI-01-PRESSAO", momento, 2.5,(Unidade)99));
    }
}

