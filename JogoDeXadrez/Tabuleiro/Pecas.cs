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

        public void DecrementarQtdMovimentos() {
            QtdMovimentos--;
        }

        public bool PodeMoverPara(Posicao pos) {
            return MovimentosPossiveis()[pos.Linha,pos.Coluna];
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiros.Linha; i++) {
                for (int j = 0; j < Tabuleiros.Colunas; j++) {
                    if (mat[i,j]) {
                        return true;
                    }
                }
            }
            return false;
        }
        public abstract bool[,] MovimentosPossiveis(); 


    }
}
