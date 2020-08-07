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

        public bool Xeque { get; set; }

        public PartidaDeXadrez() {
            Xeque = false;
            Tabuleiros = new Tabuleiros(8,8);
            Turno = 1;
            JogadorAtual = Cores.Branca;
            Pecas = new HashSet<Pecas>();
            Capturadas = new HashSet<Pecas>();
            colocarPecas();
            Terminada = false;
        }

        public Pecas ExecutaMovimento(Posicao origem, Posicao destino) {
            Pecas p = Tabuleiros.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Pecas PecaCapturada = Tabuleiros.RetirarPeca(destino);
            Tabuleiros.ColocarUmaPeca(p, destino); 
            if (PecaCapturada != null) {
                Capturadas.Add(PecaCapturada);
            }
            return PecaCapturada;

        }
        public void DesfazMovimento(Posicao origem, Posicao destino, Pecas pecaCapturada) {
            Pecas p = Tabuleiros.RetirarPeca(destino);
            p.DecrementarQtdMovimentos();
            if (pecaCapturada != null) {
                Tabuleiros.ColocarUmaPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tabuleiros.ColocarUmaPeca(p, origem);
            
        }
        public void RealizaJogada(Posicao origem, Posicao destino) {


           Pecas pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new DomainExceptions("Você não pode se colocar em cheque");
            }
            if (EstaEmXeque(Adversaria(JogadorAtual))) {
                Xeque = true;
            }
            else {
                Xeque = false;
            }
            if (TesteXequeMate(Adversaria(JogadorAtual))) {
                Terminada = true;
            }
            else {
                Turno++;
                MudaJogador();
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

        private Cores Adversaria(Cores cor) {
            if (cor == Cores.Branca) {
                return Cores.Preto;
            }
            else {
                return Cores.Branca;
            }
        }

        private Pecas Rei(Cores cor) {
            foreach (Pecas pecas in PecasEmJogo(cor)) {
                if(pecas is Rei) {
                    return pecas;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cores cor) {
            Pecas R = Rei(cor);
            if (R == null) {
                throw new DomainExceptions("Não existe rei no tabuleiro! ");
            }
            foreach (Pecas x in PecasEmJogo(Adversaria(cor))) {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha,R.Posicao.Coluna]) {
                    return true;
                }
            }
            return false;
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
            if (!Tabuleiros.peca(origem).MovimentoPossivel(destino)) {
                throw new DomainExceptions("Posição de destino Invalida!");
            }

        }

        public bool TesteXequeMate(Cores cor) {
            if (!EstaEmXeque(cor)) {
                return false;
            }
            foreach (Pecas p in PecasEmJogo(cor)) {
                bool[,] mat = p.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiros.Linha; i++) {
                    for (int j = 0; j < Tabuleiros.Colunas; j++) {
                        if (mat[i, j]) {
                            Posicao origem = p.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Pecas pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
            ColocarNovaPeca('b', 8, new Torre(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('a', 8, new Rei(Tabuleiros, Cores.Preto));
        }
    }
}
