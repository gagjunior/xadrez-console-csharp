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

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            _peca[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }
    }
}
