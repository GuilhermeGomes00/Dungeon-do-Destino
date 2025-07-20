using Text_Game.Cont;
using Text_Game.Core;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Narrativa.Introducao();
        Narrativa.Prologo();
        Narrativa.RiscoERecompensa();
        Narrativa.AlmaPerdida();
        Narrativa.ChefeFinal();

        Console.ReadKey();
    }
}
