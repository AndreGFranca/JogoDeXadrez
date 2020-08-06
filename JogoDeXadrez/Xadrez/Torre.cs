using Tabuleiro;

namespace Xadrez {
    class Torre :Pecas {
        public Torre(Tabuleiros tab, Cores cor) : base(cor, tab) {

        }
        public override string ToString() {
            return "T";
        }

    }

}
