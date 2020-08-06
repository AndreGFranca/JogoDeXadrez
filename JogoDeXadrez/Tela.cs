using Tabuleiro;
using System;

namespace JogoDeXadrez {
    class Tela {
        public static void ImprimirTabuleiro(Tabuleiros tab) {
            for (int i = 0; i < tab.Linha;i++) {
                for (int j = 0; j < tab.Colunas; j++) {
                    if (tab.Peca(i,j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(tab.Peca(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
