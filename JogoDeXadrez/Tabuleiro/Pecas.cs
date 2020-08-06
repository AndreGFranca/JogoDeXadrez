namespace Tabuleiro {
    class Pecas {
        public Posicao Posicao { get; set; }
        public Cores Cores { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiros Tabuleiros { get; protected set; }

        public Pecas(Posicao posicao, Cores cores,  Tabuleiros tabuleiro) {
            Posicao = posicao;
            Cores = cores;
            QtdMovimentos = 0;
            Tabuleiros = tabuleiro;
        }
    }
}
