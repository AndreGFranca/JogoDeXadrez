using Tabuleiro.Execeptions;

namespace Tabuleiro {
    class Tabuleiros {
        public int Linha { get; set; }
        public int Colunas { get; set; }
        private Pecas[,] Pecas;

        public Tabuleiros(int linha, int colunas) {
            Linha = linha;
            Colunas = colunas;
            Pecas = new Pecas[linha,colunas];
            
        }

        public Pecas peca(Posicao pos) {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        public Pecas Peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }
        public void ColocarUmaPeca(Pecas p, Posicao pos) {
            if (ExistePeca(pos)) {
                throw new DomainExceptions("Já existe uma peça nessa posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public bool PosicaoValida(Posicao pos) {
            if(pos.Linha< 0 || pos.Linha >= Linha || pos.Coluna < 0 || pos.Coluna >= Colunas) {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos) {
            if (!PosicaoValida(pos)) {
                throw new DomainExceptions("Posicao Inválida!");
            }
        }
    }
}
