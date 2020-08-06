using Tabuleiro;
    
namespace JogoDeXadrez {
    class Program {
        static void Main(string[] args) {
            Tabuleiros tab = new Tabuleiros(8, 8);

            Posicao Posicao = new Posicao(2, 3);
            System.Console.WriteLine($"Posicao: {Posicao}");
            
        }
    }
}
