namespace AirGuard.Dominio.Tests;

public class ValidadorDeLeituraTests
{
    [Fact]
    public void Validar_RejeitaTimestampNoFuturo()
    {
        // Arrange
        var agora = new DateTimeOffset(2026, 10, 6, 10, 0, 0, TimeSpan.Zero);
        var relogio = new RelogioFixo(agora);
        var validador = new ValidadorDeLeitura(relogio);
        var leitura = new Leitura("UTI-01-PRESSAO", agora.AddMinutes(1), 2.5, Unidade.Pascal);

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => validador.Validar(leitura));
    }

    [Fact]
    public void Validar_AceitaTimestampIgualAoAgora()
    {
        // Arrange
        var agora = new DateTimeOffset(2026, 10, 6, 10, 0, 0, TimeSpan.Zero);
        var relogio = new RelogioFixo(agora);
        var validador = new ValidadorDeLeitura(relogio);
        var leitura = new Leitura("UTI-01-PRESSAO", agora, 2.5, Unidade.Pascal);

        // Act
        var erro = Record.Exception(() => validador.Validar(leitura));

        // Assert
        Assert.Null(erro);
    }
}
