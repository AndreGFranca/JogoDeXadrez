using Tabuleiro;

namespace Xadrez {
    class Rei : Pecas{
        public Rei(Tabuleiros tab, Cores cor) : base(cor, tab) {

        }
        public override string ToString() {
            return "R";
        }
    }
}
