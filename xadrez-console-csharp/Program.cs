using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(0, 0));
                tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(1, 3));
                tabuleiro.ColocarPeca(new Rei(Cor.Preta, tabuleiro), new Posicao(0, 2));
                
                tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new Posicao(0, 6));
                tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new Posicao(2, 3));
                tabuleiro.ColocarPeca(new Rei(Cor.Branca, tabuleiro), new Posicao(3, 2));

                Tela.ImprimirTabuleiro(tabuleiro);
            }
            catch (TabuleiroExeption err)
            {
                Console.WriteLine(err.Message);
            }

        }
    }
}