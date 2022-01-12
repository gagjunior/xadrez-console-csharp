namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] _peca;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _peca = new Peca[Linhas, Colunas];
        }

        public Peca Peca(int linha, int coluna) 
        { 
            return _peca[linha, coluna]; 
        }

        public Peca Peca(Posicao posicao)
        {
            return _peca[posicao.Linha, posicao.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroExeption("Já existe uma peça nessa posição!!!");
            }
            _peca[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return Peca(posicao) != null;
        }

        public bool PosicaoEhValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoEhValida(posicao))
            {
                throw new TabuleiroExeption("Posição não é válida!!!");
            }
        }
    }
}
