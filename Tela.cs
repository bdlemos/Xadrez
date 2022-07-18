using System;
using tabuleiro;

namespace xadrez{
    static class Tela{
        public static void imprimirTabuleiro(Tabuleiro tab){
            for (int i = 0; i < tab.linhas; i++){
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++){
                    if (tab.peca(i,j) != null){
                        Tela.imprimirPeca(tab.peca(i,j));
                        System.Console.Write(" ");
                    }
                    else{
                        System.Console.Write("- ");
                    }
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h ");
        }

        public static void imprimirPeca(Peca peca){
            if (peca.cor == Cor.Branca){
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}