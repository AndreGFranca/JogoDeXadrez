using Tabuleiro;

namespace Xadrez {
    class Peao : Pecas {
        public Peao(Tabuleiros tab, Cores cor, PartidaDeXadrez partida) : base(cor, tab) {
            Partida = partida;
        }

        private bool ExisteInimigo(Posicao pos) {
            Pecas p = Tabuleiros.peca(pos);
            return p != null && p.Cores != Cores;
        }

        private bool Livre(Posicao pos) {
            return Tabuleiros.peca(pos) == null;
        }
        private PartidaDeXadrez Partida;


        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiros.Linha, Tabuleiros.Colunas];
            Posicao pos = new Posicao(0, 0);

            if(Cores == Cores.Branca) {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiros.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiros.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiros.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiros.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //#Jogada especial en passant
                if (Posicao.Linha == 3) {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiros.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiros.peca(esquerda) == Partida.VulneravelEnPassant) {
                        mat[esquerda.Linha -1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiros.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiros.peca(direita) == Partida.VulneravelEnPassant) {
                        mat[direita.Linha -1, direita.Coluna] = true;
                    }
                }
            }
            else {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiros.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiros.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiros.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiros.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //#Jogada especial en passant
                if (Posicao.Linha == 4) {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiros.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiros.peca(esquerda) == Partida.VulneravelEnPassant) {
                        mat[esquerda.Linha +1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiros.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiros.peca(direita) == Partida.VulneravelEnPassant) {
                        mat[direita.Linha +1, direita.Coluna] = true;
                    }
                }

            }
            //acima
            return mat;
        }
        private bool podeMover(Posicao pos) {
            Pecas p = Tabuleiros.peca(pos);
            return p == null || p.Cores != Cores;

        }
        public override string ToString() {
            return "P";
        }
    }
}
