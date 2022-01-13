using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrix = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            //Acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoEhValida(posicao) && this.PodeMover(posicao))
            {
                matrix[posicao.Linha, posicao.Coluna] = true;
            }

            //NE
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoEhValida(posicao) && this.PodeMover(posicao))
            {
                matrix[posicao.Linha, posicao.Coluna] = true;
            }

            //Direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoEhValida(posicao) && this.PodeMover(posicao))
            {
                matrix[posicao.Linha, posicao.Coluna] = true;
            }

            //SE
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoEhValida(posicao) && this.PodeMover(posicao))
            {
                matrix[posicao.Linha, posicao.Coluna] = true;
            }

            //Abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoEhValida(posicao) && this.PodeMover(posicao))
            {
                matrix[posicao.Linha, posicao.Coluna] = true;
            }

            //SO
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoEhValida(posicao) && this.PodeMover(posicao))
            {
                matrix[posicao.Linha, posicao.Coluna] = true;
            }

            //Esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoEhValida(posicao) && this.PodeMover(posicao))
            {
                matrix[posicao.Linha, posicao.Coluna] = true;
            }

            //NO
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoEhValida(posicao) && this.PodeMover(posicao))
            {
                matrix[posicao.Linha, posicao.Coluna] = true;
            }

            return matrix;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
