using Tabuleiro;

namespace Xadrez {
    class Bispo : Pecas {
        public Bispo(Tabuleiros tab, Cores cor) : base(cor, tab) {

        }
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiros.Linha, Tabuleiros.Colunas];
            Posicao pos = new Posicao(0, 0);

            //NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiros.peca(pos) != null && Tabuleiros.peca(pos).Cores != Cores) {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }


            //SO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiros.peca(pos) != null && Tabuleiros.peca(pos).Cores != Cores) {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            //SE
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiros.peca(pos) != null && Tabuleiros.peca(pos).Cores != Cores) {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            //NE
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna +1);
            while (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiros.peca(pos) != null && Tabuleiros.peca(pos).Cores != Cores) {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            return mat;
        }
        private bool podeMover(Posicao pos) {
            Pecas p = Tabuleiros.peca(pos);
            return p == null || p.Cores != Cores;

        }
        public override string ToString() {
            return "B";
        }


    }

}
