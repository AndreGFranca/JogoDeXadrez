using Tabuleiro;

namespace Xadrez {
    class Rei : Pecas{
        public Rei(Tabuleiros tab, Cores cor, PartidaDeXadrez partida) : base(cor, tab) {
            Partida = partida;
        }
        public PartidaDeXadrez Partida { get; private set; }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiros.Linha, Tabuleiros.Colunas];
            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //NE
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //SE
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //SO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //#Jogada especial
            //#Jogada especial Roque Pequeno
            if (QtdMovimentos == 0 && !Partida.Xeque) {
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
           //         Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                    if (Tabuleiros.peca(p1) == null && Tabuleiros.peca(p2) == null) {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
                //#Jogada especial Roque Grande

                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posT2)) {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna- 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiros.peca(p1) == null && Tabuleiros.peca(p2) == null && Tabuleiros.peca(p3) == null) {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                        //
                    }
                }
            }

            

            return mat;
        }
        private bool TesteTorreParaRoque(Posicao pos) {
            Pecas p = Tabuleiros.peca(pos);
            return p != null && p is Torre && p.Cores == Cores && p.QtdMovimentos == 0;
        }
        private bool podeMover(Posicao pos) {
            Pecas p = Tabuleiros.peca(pos);
            return p == null || p.Cores != Cores;

        }
        public override string ToString() {
            return "R";
        }
    }
}
