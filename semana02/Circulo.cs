// ======================= CLASE CIRCULO =======================

public class Circulo
{
    // Encapsulación del radio
    private double radio;

    // Propiedad con validación
    public double Radio
    {
        get { return radio; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("El radio debe ser mayor que cero.");
            radio = value;
        }
    }

    // Constructor
    public Circulo(double radio)
    {
        Radio = radio;
    }

    // Método para calcular el área
    // Fórmula: PI * r^2
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // Método para calcular el perímetro (circunferencia)
    // Fórmula: 2 * PI * r
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}
