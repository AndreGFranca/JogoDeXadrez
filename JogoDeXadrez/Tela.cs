using Tabuleiro;
using Xadrez;
using System;

namespace JogoDeXadrez {
    class Tela {
        public static void ImprimirTabuleiro(Tabuleiros tab) {

            for (int i = 0; i < tab.Linha;i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++) {
                    ImprimirPeca(tab.Peca(i,j));
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }
        public static void ImprimirTabuleiro(Tabuleiros tab, bool[,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Linha; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++) {

                    if (posicoesPossiveis[i, j] == true) {
                        Console.BackgroundColor = fundoAlterado;
                     }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    
                    ImprimirPeca(tab.Peca(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            //Console.ForegroundColor = fundoOriginal;

        }

        public static PosicaoXadrez LerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Pecas peca) {
            if (peca == null) {
                Console.Write("- ");
            }
            else {


                if (peca.Cores == Cores.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
