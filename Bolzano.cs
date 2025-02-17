namespace AnalisisProject;

static class Bolzano // Clase que utiliza en diferentes formas las hipotesis para el primer Teorema de Bolzano
{
    //Este metodo devuelve un tupla que representa un intervalo cerrado  en el que hay al menos una raiz
    static public (int, int) FindInterval(Polinomio polinomio)
    {
        
        for (int i = 0; ; i++)
        {
            if(polinomio.Evaluate(-Math.Pow(2, i)) * polinomio.Evaluate(Math.Pow(2, i)) < 0)
            {
                (int, int) interval = (-(int)Math.Pow(2, i), (int)Math.Pow(2, i));
                return interval;
            }
        }
    }
    //Permite checar la condicion de bolzano en un intervalo para la existencia de raices
    static public bool Check((double,double) intervalo,Polinomio polinomio)
    {
        if(polinomio.Evaluate(intervalo.Item1)*polinomio.Evaluate(intervalo.Item2)<0)
        {
            return true;
        }
        return false;
    }
}
public class Bissections
{
    //Instance Variables
    (int, int) initialinterval;
    double tolerance;
    int numberofiterations;
    Polinomio polinomio;
    double root;
    //Properties
    private (int, int) InitialInterval
    {
        get { return initialinterval; }
    }
    private double Tolerance
    {
        get
        {
            return tolerance;
        }
    }
    private Polinomio polinomio1
    {
        get
        {
            return polinomio;
        }
    }
    private int NumberOfIterations
    {
        get 
        {
          return numberofiterations; 
        }
    }
    public double Root
    {
        get 
        {
            return root; 
        }
    }

    //Methods
    public Bissections (Polinomio polinomio, double tolerance = 0.00000001)
    {
        this.initialinterval = Bolzano.FindInterval(polinomio);
        this.tolerance = tolerance;
        this.polinomio = polinomio;
        this.numberofiterations = (int)(Math.Log2((this.InitialInterval.Item1 - this.InitialInterval.Item2) / this.Tolerance)) + 1;
        this.root = FindRoot(this.InitialInterval,this.NumberOfIterations); 
    }
    private double FindRoot((double, double) interval, int n)
    {
        double a = interval.Item1;
        double b = interval.Item2;
        double c = (a + b) / 2;
        //Caso Base
        if (this.polinomio.Evaluate(c) == 0 || n == 0)
        {
            Console.WriteLine("La raiz es :", c);
            return c;
        }
        //Caso Recursivo
        if (Bolzano.Check((a, c),this.polinomio))
        {
           return FindRoot((a,c), n - 1);
        }
        else
        {
            return FindRoot((c,b), n - 1);
        }
    }
}
