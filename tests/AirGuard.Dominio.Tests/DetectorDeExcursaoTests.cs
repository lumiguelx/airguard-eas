namespace AirGuard.Dominio.Tests;

public class DetectorDeExcursaoTests
{
    [Fact]
    public void Registrar_ForaPorMaisQueATolerancia_AbreExcursao()
    {
        var detector = new DetectorDeExcursao(TimeSpan.FromSeconds(60));
        var inicio = new DateTimeOffset(2026, 1, 1, 10, 0, 5, TimeSpan.Zero);

        detector.Registrar(inicio, Conformidade.NaoConforme);
        detector.Registrar(inicio.AddSeconds(65), Conformidade.NaoConforme);

        Assert.True(detector.EmExcursao);
    }

    [Fact]
    public void Registrar_VoltaParaDentroAntesDaTolerancia_ZeraAContagem()
    {
        var detector = new DetectorDeExcursao(TimeSpan.FromSeconds(60));
        var inicio = new DateTimeOffset(2026, 1, 1, 10, 0, 5, TimeSpan.Zero);

        detector.Registrar(inicio, Conformidade.NaoConforme);
        detector.Registrar(inicio.AddSeconds(20), Conformidade.Conforme);
        detector.Registrar(inicio.AddSeconds(45), Conformidade.NaoConforme);
        detector.Registrar(inicio.AddSeconds(65), Conformidade.NaoConforme);

        Assert.False(detector.EmExcursao);
    }

    [Fact]
    public void Registrar_ForaExatamenteATolerancia_NaoAbreExcursao()
    {
        var detector = new DetectorDeExcursao(TimeSpan.FromSeconds(60));
        var inicio = new DateTimeOffset(2026, 1, 1, 10, 0, 5, TimeSpan.Zero);

        detector.Registrar(inicio, Conformidade.NaoConforme);
        detector.Registrar(inicio.AddSeconds(60), Conformidade.NaoConforme);

        Assert.False(detector.EmExcursao);
    }
}
