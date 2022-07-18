using System;
using tabuleiro;

namespace xadrez{
    class Program{
        static void Main(){
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            System.Console.WriteLine(pos);
            System.Console.WriteLine(pos.toPosicao());
        }
    }
}