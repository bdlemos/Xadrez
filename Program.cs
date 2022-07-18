using System;
using tabuleiro;

namespace xadrez{
    class Program{
        static void Main(){
            Tabuleiro tab = new Tabuleiro(8,8);
            Tela.imprimirTabuleiro(tab);
        }
    }
}