using Tabuleiro;
using Xadrez;
    
namespace JogoDeXadrez {
    class Program {
        static void Main(string[] args) {
            Tabuleiros tab = new Tabuleiros(8, 8);

            tab.ColocarUmaPeca(new Torre(tab, Cores.Preto), new Posicao(0, 0));
            tab.ColocarUmaPeca(new Torre(tab, Cores.Preto), new Posicao(1, 3));
            tab.ColocarUmaPeca(new Rei(tab, Cores.Preto), new Posicao(2, 4));
            

            Tela.ImprimirTabuleiro(tab);

            
        }
    }
}
