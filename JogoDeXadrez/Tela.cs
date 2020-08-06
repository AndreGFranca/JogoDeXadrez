using Tabuleiro;
using System;

namespace JogoDeXadrez {
    class Tela {
        public static void ImprimirTabuleiro(Tabuleiros tab) {

            for (int i = 0; i < tab.Linha;i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++) {
                    if (tab.Peca(i,j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Tela.ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        public static void ImprimirPeca(Pecas peca) {
            if (peca.Cores == Cores.Branca) {
                Console.Write(peca);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
                }
        }
    }
}
