﻿using Tabuleiro;
using Tabuleiro.Execeptions;
using Xadrez;
using System;
    
namespace JogoDeXadrez {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
                while (!partidaDeXadrez.Terminada) {
                    try {

                    
                    Console.Clear();
                        Tela.ImprimirPartida(partidaDeXadrez);                  


                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Clear();
                        partidaDeXadrez.ValidarPosicaoOrigem(origem);
                    bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiros.peca(origem).MovimentosPossiveis();
                    Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiros, posicoesPossiveis);
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partidaDeXadrez.ValidarPosicaoDeDestino(origem,destino);

                    partidaDeXadrez.RealizaJogada(origem, destino);
                    }
                    catch(DomainExceptions e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }


                }
                Console.Clear();
                Tela.ImprimirPartida(partidaDeXadrez);


                
            }

            catch(DomainExceptions e) {
                System.Console.WriteLine(e.Message);
            }
            
        }
    }
}
