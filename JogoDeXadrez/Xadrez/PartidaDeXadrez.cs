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
        public Pecas VulneravelEnPassant { get; private set; }

        public bool Xeque { get; set; }

        public PartidaDeXadrez() {
            Xeque = false;
            Tabuleiros = new Tabuleiros(8,8);
            Turno = 1;
            JogadorAtual = Cores.Branca;
            Pecas = new HashSet<Pecas>();
            Capturadas = new HashSet<Pecas>();
            VulneravelEnPassant = null;
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
            //#Jogada Especial Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(destino.Linha, origem.Coluna + 1);
                Pecas T = Tabuleiros.RetirarPeca(origemT);
                T.IncrementarQtdMovimentos();
                Tabuleiros.ColocarUmaPeca(T, destinoT);
            }

            //#Jogada Especial Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(destino.Linha, origem.Coluna - 1);
                Pecas T = Tabuleiros.RetirarPeca(origemT);
                T.IncrementarQtdMovimentos();
                Tabuleiros.ColocarUmaPeca(T, destinoT);
            }

            //#Jogada especial En passant
            if(p is Peao) {
                if (origem.Coluna != destino.Coluna && PecaCapturada == null) {
                    Posicao posP;
                    if(p.Cores == Cores.Branca) {
                        posP = new Posicao(destino.Linha + 1, destino.Coluna);
                    }
                    else {
                        posP = new Posicao(destino.Linha - 1, destino.Coluna);
                    }
                    PecaCapturada = Tabuleiros.RetirarPeca(posP);
                    Capturadas.Add(PecaCapturada);
                }
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

            //JogadaEspecialRoque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(destino.Linha, origem.Coluna + 1);
                Pecas T = Tabuleiros.RetirarPeca(destinoT);
                T.DecrementarQtdMovimentos();
                Tabuleiros.ColocarUmaPeca(T, origemT);
            }
            //JogadaEspecialRoque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(destino.Linha, origem.Coluna - 1);
                Pecas T = Tabuleiros.RetirarPeca(destinoT);
                T.DecrementarQtdMovimentos();
                Tabuleiros.ColocarUmaPeca(T, origemT);
            }

            //#Jogada special En Passant
            if (p is Peao) {
                if (origem.Coluna != destino.Coluna && pecaCapturada  == VulneravelEnPassant) {
                    Pecas peao = Tabuleiros.RetirarPeca(destino);
                    Posicao posP;
                    if(p.Cores == Cores.Branca) {
                        posP = new Posicao(3, destino.Coluna);
                    }
                    else {
                        posP = new Posicao(4, destino.Coluna);
                    }
                    Tabuleiros.ColocarUmaPeca(peao, posP);
                }
            }

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
            Pecas P = Tabuleiros.peca(destino);
            //#JogadaEspecial En Passant
            if (P is Peao && (destino.Linha == origem.Linha + 2 || destino.Linha == origem.Linha - 2)) {
                VulneravelEnPassant = P;
            }
            else {
                VulneravelEnPassant = null;
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
            ColocarNovaPeca('a', 1, new Torre(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiros, Cores.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiros, Cores.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiros, Cores.Branca));

            ColocarNovaPeca('a', 2, new Peao(Tabuleiros, Cores.Branca,this));
            ColocarNovaPeca('b', 2, new Peao(Tabuleiros, Cores.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(Tabuleiros, Cores.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(Tabuleiros, Cores.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(Tabuleiros, Cores.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(Tabuleiros, Cores.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(Tabuleiros, Cores.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(Tabuleiros, Cores.Branca, this));


            ColocarNovaPeca('a', 8, new Torre(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiros, Cores.Preto));            
            ColocarNovaPeca('d', 8, new Dama(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiros, Cores.Preto, this));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiros, Cores.Preto));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiros, Cores.Preto));

            ColocarNovaPeca('a', 7, new Peao(Tabuleiros, Cores.Preto, this) );
            ColocarNovaPeca('b', 7, new Peao(Tabuleiros, Cores.Preto, this));
            ColocarNovaPeca('c', 7, new Peao(Tabuleiros, Cores.Preto, this));
            ColocarNovaPeca('d', 7, new Peao(Tabuleiros, Cores.Preto, this));
            ColocarNovaPeca('e', 7, new Peao(Tabuleiros, Cores.Preto, this));
            ColocarNovaPeca('f', 7, new Peao(Tabuleiros, Cores.Preto, this));
            ColocarNovaPeca('g', 7, new Peao(Tabuleiros, Cores.Preto, this));
            ColocarNovaPeca('h', 7, new Peao(Tabuleiros, Cores.Preto, this));


        }
    }
}
