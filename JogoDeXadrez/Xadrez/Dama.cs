using Tabuleiro;

namespace Xadrez {
    class Dama : Pecas {
        public Dama(Tabuleiros tab, Cores cor) : base(cor, tab) {

        }
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiros.Linha, Tabuleiros.Colunas];
            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiros.peca(pos) != null && Tabuleiros.peca(pos).Cores != Cores) {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }


            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiros.peca(pos) != null && Tabuleiros.peca(pos).Cores != Cores) {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiros.peca(pos) != null && Tabuleiros.peca(pos).Cores != Cores) {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiros.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiros.peca(pos) != null && Tabuleiros.peca(pos).Cores != Cores) {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }
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
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
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
            return "D";
        }
    }
}
