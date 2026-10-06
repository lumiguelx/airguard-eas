namespace AirGuard.Dominio;

public class Faixa
{
    public double Minimo { get; }
    public double Maximo { get; }

    public Faixa(double minimo, double maximo)
    {
        Minimo = minimo;
        Maximo = maximo;
    }

    public bool Contem(double valor)
    {
        return valor >= Minimo && valor <= Maximo;
    }
}

