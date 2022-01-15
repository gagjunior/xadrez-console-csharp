using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        private HashSet<Peca> _pecas;
        private HashSet<Peca> _capturadas;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdMovimentos();

            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null)
            {
                _capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tabuleiro.Peca(pos) == null)
            {
                throw new TabuleiroExeption("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.Peca(pos).Cor)
            {
                throw new TabuleiroExeption("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiro.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroExeption("Não há movimentos possiveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroExeption("Posição de destino inválida!");
            }
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in _capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in _pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            _pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('A', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('H', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('D', 2, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('D', 1, new Rei(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('C', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('C', 2, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('E', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('E', 2, new Torre(Cor.Branca, Tabuleiro));

            ColocarNovaPeca('C', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('C', 7, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('D', 7, new Rei(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('E', 7, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('E', 8, new Torre(Cor.Preta, Tabuleiro));

            
        }
    }
}
