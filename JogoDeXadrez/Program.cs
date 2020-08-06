using Tabuleiro;
using Tabuleiro.Execeptions;
using Xadrez;
using System;
    
namespace JogoDeXadrez {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
                while (!partidaDeXadrez.Terminada) {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiros);
                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Clear();

                    bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiros.peca(origem).MovimentosPossiveis();
                    Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiros, posicoesPossiveis);
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partidaDeXadrez.ExecutaMovimento(origem, destino);
                    
                }


                
            }

            catch(DomainExceptions e) {
                System.Console.WriteLine(e.Message);
            }
            
        }
    }
}
