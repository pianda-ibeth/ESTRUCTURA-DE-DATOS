using System;

public class Rectangulo
{
    // Propiedades
    public double Ancho { get; set; }
    public double Alto { get; set; }

    // Constructor
    public Rectangulo(double ancho, double alto)
    {
        Ancho = ancho;
        Alto = alto;
    }

    // Método para calcular el área
    public double CalcularArea()
    {
        return Ancho * Alto;
    }

    // Método para calcular el perímetro
    public double CalcularPerimetro()
    {
        return 2 * (Ancho + Alto);
    }
}
