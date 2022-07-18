using System;
using tabuleiro;

namespace xadrez{
    static class Tela{
        public static void imprimirTabuleiro(Tabuleiro tab){
            for (int i = 0; i < tab.linhas; i++){
                for (int j = 0; j < tab.colunas; j++){
                    if (tab.peca(i,j) != null)
                        System.Console.Write( tab.peca(i,j) + " ");
                    else
                        System.Console.Write("- ");
                }
                System.Console.WriteLine();
            }
        }
    }
    
}