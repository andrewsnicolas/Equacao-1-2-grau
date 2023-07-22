using System.ComponentModel.Design;

Console.Write("Olá, qual é o seu nome? ");
string nome = Console.ReadLine();
int dec = 0;
do
{
    Console.Write("Olá {0}! Tudo bem? Bem vindo! Aqui você poderá achar as respostas\n de equação de primeiro e segundo grau" +
    "Qual equação você quer fazer?\n" +
    "[1]Equação de primeiro grau\n" +
    "[2]Equação de segundo grau\n" +
    "Digite: ", nome);
    dec = Convert.ToInt32(Console.ReadLine());
} while (dec < 1 || dec > 2);
double res = 0;
string equacao = "";
if (dec == 1)
{
    Console.Write("Você escolheu a equação de 1° grau, digite a equação aqui: ");
    equacao = Console.ReadLine().Trim();
    int posigual = Convert.ToInt32(equacao.IndexOf("="));
    int sinal = Convert.ToInt32(equacao.IndexOf("+"));
    if (sinal == -1) sinal = Convert.ToInt32(equacao.IndexOf("-"));
    if (sinal == -1) sinal = Convert.ToInt32(equacao.IndexOf("*"));
    if (sinal == -1) sinal = Convert.ToInt32(equacao.IndexOf("/"));
    string n1 = equacao.Substring(posigual + 1);
    string n2 = equacao.Substring((sinal + 1), (posigual - 2));
    int m1 = Convert.ToInt32(n1);
    int m2 = Convert.ToInt32(n2);
    switch (equacao.Substring(sinal, sinal))
    {
        case "+": res = m1 - m2; break;
        case "-": res = m1 + m2; break;
        case "*": res = m1 / m2; break;
        case "/": res = m1 * m2; break;
    }
    Console.WriteLine("x = " + res);
    Console.ReadKey();

}
else
{
    do
    {
        Console.WriteLine($"{nome}, qual tipo de equação de 2° grau você quer saber a resposta?\n" +
            "[1]Completa\n" +
            "[2]Incompleta");
        dec = Convert.ToInt32(Console.ReadLine());
    } while (dec < 1 || dec > 2);
    if (dec == 1)
    {
        double a, b, c;
        string sinalA = "+", sinalB = "+", sinalC = "+";
        Console.Write("Você escolheu a equação de 2° grau completa!\nPor favor digite a equação: ");
        equacao = Console.ReadLine();
        equacao = equacao.Replace(" ", String.Empty);
        Console.WriteLine(equacao);
        if (equacao.Substring(0, 0) == "-")
        {
            sinalA = equacao.Substring(0, 0);
            equacao = equacao.Substring(1);
        }
        int v1 = equacao.IndexOf("x²");
        if (v1 == 0) a = 1;
        else a = Convert.ToDouble(equacao.Substring(0, v1));
        string equacao2 = equacao.Substring(v1 + 2);
        sinalB = equacao.Substring(v1 + 1, v1 + 2);
        int pos = equacao2.IndexOf("x");
        if (pos == 1) b = 1;
        else b = Convert.ToDouble(equacao2.Substring(0, pos));
        string equacao3 = equacao2.Substring(pos + 1);
        sinalC = equacao3.Substring(0, 1);
        equacao3 = equacao3.Substring(1);
        pos = equacao3.IndexOf("=");
        c = Convert.ToDouble(equacao3.Substring(0, pos));
        if (sinalA == "-") a = a - 2 * a;
        if (sinalB == "-") b = b - 2 * b;
        if (sinalC == "-") c = c - 2 * c;
        double delta = (Math.Pow(b, 2)) - 4 * a * c;
        double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
        double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
        Console.WriteLine($"Valores de x:");
        if (Double.IsNaN(x1) == true) Console.WriteLine($"({b}+√{delta})/2*{a}");
        else Console.WriteLine(x1);
        if (Double.IsNaN(x2) == true) Console.WriteLine($"({b}-√{delta})/2*{a}");
        else Console.WriteLine(x2);
        Console.ReadKey();
    }
    else
    {
        Console.Write("Você escolheu a equação de 2° grau incompleta!\nPor favor, digite a equação: ");
        equacao = Console.ReadLine();
        equacao = equacao.Replace(" ", String.Empty);
        int posigual = equacao.IndexOf("=");
        int sinal = equacao.IndexOf("+");
        if (sinal == -1) sinal = equacao.IndexOf("-");
        if (sinal == -1) sinal = equacao.IndexOf("*");
        if (sinal == -1) sinal = equacao.IndexOf("/");
        string n1 = equacao.Substring(posigual + 1);
        string n2 = equacao.Substring(sinal + 1, posigual - 3);
        double m1 = Convert.ToDouble(n1);
        double m2 = Convert.ToDouble(n2);
        switch (equacao.Substring(sinal, sinal-1))
        {
            case "+": res = m1 - m2; break;
            case "-": res = m1 + m2; break;
            case "*": res = m1 / m2; break;
            case "/": res = m1 * m2; break;
        }
        if(Double.IsNaN(Math.Sqrt(res)) == true) Console.WriteLine("x = √" +res+ " ou -√"+res);
        else Console.WriteLine("x = " + Math.Sqrt(res) + " ou -"+ Math.Sqrt(res));
        Console.ReadKey();
    }
}