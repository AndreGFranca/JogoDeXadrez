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

        public Pecas Peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }
        public void ColocarUmaPeca(Pecas p, Posicao pos) {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
    }
}
