using System;
using tabuleiro;

namespace xadrez{
    class Program{
        static void Main(){
            try{
                Tabuleiro tab = new Tabuleiro(8,8);
                
                tab.colocarPeca(new Torre(tab, Cor.Preta),new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta),new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta),new Posicao(0, 4));
                
                PosicaoXadrez pos =  new PosicaoXadrez('h', 1);
                tab.colocarPeca(new Rei(tab, Cor.Branca), pos.toPosicao());
                
                Tela.imprimirTabuleiro(tab);
            }
            catch(TabuleiroException e){
                System.Console.WriteLine(e.Message);
            }
        }
    }
}