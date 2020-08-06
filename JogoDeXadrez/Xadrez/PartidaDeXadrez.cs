using Tabuleiro.Execeptions;
using Tabuleiro;

namespace Xadrez {
    class PartidaDeXadrez {
        public Tabuleiros Tabuleiros { get; private set; }
        public int Turno { get; private set; }
        public Cores JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez() {
            Tabuleiros = new Tabuleiros(8,8);
            Turno = 1;
            JogadorAtual = Cores.Branca;
            colocarPecas();
            Terminada = false;
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Pecas p = Tabuleiros.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Pecas PecaCapturada = Tabuleiros.RetirarPeca(destino);
            Tabuleiros.ColocarUmaPeca(p, destino);

        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();

        }

        public void MudaJogador() {
            if (JogadorAtual == Cores.Branca) {
                JogadorAtual = Cores.Preto;
            }
            else {
                JogadorAtual = Cores.Branca;
            }
        }

        public void ValidarPosicaoOrigem(Posicao pos) {
            if (Tabuleiros.peca(pos) == null) {
                throw new DomainExceptions("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiros.peca(pos).Cores) {
                throw new DomainExceptions("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiros.peca(pos).ExisteMovimentosPossiveis()) {
                throw new DomainExceptions("Não há movimentos possíveis para a peça de origem escolhida!");
            }

        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!Tabuleiros.peca(origem).PodeMoverPara(destino)) {
                throw new DomainExceptions("Posição de destino Invalida!");
            }

        }
        private void colocarPecas() {
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Rei(Tabuleiros, Cores.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Preto), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Preto), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Preto), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Torre(Tabuleiros, Cores.Preto), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiros.ColocarUmaPeca(new Rei(Tabuleiros, Cores.Preto), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
