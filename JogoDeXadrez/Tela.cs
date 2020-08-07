using Tabuleiro;
using Xadrez;
using System.Collections.Generic;
using System;

namespace JogoDeXadrez {
    class Tela {
        public static void ImprimirPartida(PartidaDeXadrez partida) {
            ImprimirTabuleiro(partida.Tabuleiros);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine($"\nTurno: {partida.Turno}");
            if (!partida.Terminada) {
                Console.WriteLine($"AguardandoJogada: {partida.JogadorAtual}");
                if (partida.Xeque) {
                    Console.WriteLine("XEQUE!");
                }
            }
            else {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }

        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cores.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cores.Preto));
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void ImprimirConjunto(HashSet<Pecas> conjunto) {
            Console.Write("[");
            foreach (Pecas pecas in conjunto) {
                Console.Write(pecas + " ");
            }
            Console.Write("]");
        }

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
                Console.BackgroundColor = fundoOriginal;
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
