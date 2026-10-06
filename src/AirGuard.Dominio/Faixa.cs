namespace AirGuard.Dominio;

public class Faixa
{
    public double? Minimo { get; }
    public double? Maximo { get; }

    public Faixa(double? minimo, double? maximo)
    {
        if (minimo > maximo)
        {
            throw new ArgumentException("O mínimo não pode ser maior que o máximo.");
        }
        if (minimo is null && maximo is null)
        {
            throw new ArgumentException("A faixa precisa de pelo menos um limite.");
        }


        Minimo = minimo;
        Maximo = maximo;
    }

    public bool Contem(double valor)
    {
        return (Minimo is null || valor >= Minimo) && (Maximo is null || valor <= Maximo);
    }
}
