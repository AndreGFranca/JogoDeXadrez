using Tabuleiro;

namespace Xadrez {
    class Rei : Pecas{
        public Rei(Tabuleiros tab, Cores cor) : base(cor, tab) {

        }
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
            return mat;
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
