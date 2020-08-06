using Tabuleiro;
using Tabuleiro.Execeptions;
using Xadrez;
using System;
    
namespace JogoDeXadrez {
    class Program {
        static void Main(string[] args) {
            try {
                PosicaoXadrez PosicaoXadrez = new PosicaoXadrez('c',7);

                Console.WriteLine(PosicaoXadrez);
                Console.WriteLine(PosicaoXadrez.ToPosicao());

                Tabuleiros tab = new Tabuleiros(8, 8);

                tab.ColocarUmaPeca(new Torre(tab, Cores.Preto), new Posicao(0, 0));
                tab.ColocarUmaPeca(new Torre(tab, Cores.Preto), new Posicao(1, 3));
                tab.ColocarUmaPeca(new Rei(tab, Cores.Preto), new Posicao(0, 7));

                tab.ColocarUmaPeca(new Torre(tab, Cores.Branca), new Posicao(3, 0));
                tab.ColocarUmaPeca(new Torre(tab, Cores.Branca), new Posicao(2, 3));
                tab.ColocarUmaPeca(new Rei(tab, Cores.Branca), new Posicao(4, 7));


                Tela.ImprimirTabuleiro(tab);
            }

            catch(DomainExceptions e) {
                System.Console.WriteLine(e.Message);
            }
            
        }
    }
}
