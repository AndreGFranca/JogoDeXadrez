using Tabuleiro.Execeptions;
using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez {
    class PartidaDeXadrez {
        public Tabuleiros Tabuleiros { get; private set; }
        public int Turno { get; private set; }
        public Cores JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public HashSet<Pecas> Pecas { get; set; }
        public HashSet<Pecas> Capturadas { get; set; }

        public PartidaDeXadrez() {
            Tabuleiros = new Tabuleiros(8,8);
            Turno = 1;
            JogadorAtual = Cores.Branca;
            Pecas = new HashSet<Pecas>();
            Capturadas = new HashSet<Pecas>();
            colocarPecas();
            Terminada = false;
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Pecas p = Tabuleiros.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Pecas PecaCapturada = Tabuleiros.RetirarPeca(destino);
            Tabuleiros.ColocarUmaPeca(p, destino); 
            if (PecaCapturada != null) {
                Capturadas.Add(PecaCapturada);
            }

        }

        public HashSet<Pecas> PecasCapturadas(Cores cor) {
            HashSet<Pecas> aux = new HashSet<Pecas>();
            foreach (Pecas peca in Capturadas) {
                if(peca.Cores == cor) {
                    aux.Add(peca);
                }

            }
            return aux;
        }

        public HashSet<Pecas> PecasEmJogo(Cores cor) {
            HashSet<Pecas> aux = new HashSet<Pecas>();
            foreach (Pecas peca in Pecas) {
                if (peca.Cores == cor) {
                    aux.Add(peca);
                }

            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }


        public void RealizaJogada(Posicao origem, Posicao destino) {
            
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();

        }

        public void MudaJogador() {
            if (JogadorAtual == Cores.Branca) {
                JogadorAtual = Cores.Preto;
            }
            else {
                JogadorAtual = Cores.Branca;
            }
        }

        public void ValidarPosicaoOrigem(Posicao pos) {
            if (Tabuleiros.peca(pos) == null) {
                throw new DomainExceptions("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiros.peca(pos).Cores) {
                throw new DomainExceptions("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiros.peca(pos).ExisteMovimentosPossiveis()) {
                throw new DomainExceptions("Não há movimentos possíveis para a peça de origem escolhida!");
            }

        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!Tabuleiros.peca(origem).PodeMoverPara(destino)) {
                throw new DomainExceptions("Posição de destino Invalida!");
            }

        }

        public void ColocarNovaPeca(char coluna, int linha, Pecas peca) {
            Tabuleiros.ColocarUmaPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void colocarPecas() {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiros, Cores.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('c', 8, new Torre(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiros, Cores.Preto));
        }
    }
}
