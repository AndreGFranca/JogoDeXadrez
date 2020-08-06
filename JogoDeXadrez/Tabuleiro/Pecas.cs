namespace Tabuleiro {
   abstract class Pecas {
        public Posicao Posicao { get; set; }
        public Cores Cores { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiros Tabuleiros { get; protected set; }

        public Pecas(Cores cores,  Tabuleiros tabuleiro) {
            Posicao = null;
            Cores = cores;
            QtdMovimentos = 0;
            Tabuleiros = tabuleiro;

        }

        public void IncrementarQtdMovimentos() {
            QtdMovimentos++;
        }
        public abstract bool[,] MovimentosPossiveis(); 
    }
}
