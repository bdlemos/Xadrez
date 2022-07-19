using System;
using tabuleiro;

namespace xadrez{
    static class Tela{
        public static void imprimirTabuleiro(Tabuleiro tab){
            for (int i = 0; i < tab.linhas; i++){
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++){
                        Tela.imprimirPeca(tab.peca(i,j));
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h ");
        }
        
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPOssiveis){
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++){
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++){
                    if(posicoesPOssiveis[i, j]){
                        Console.BackgroundColor = fundoAlterado;
                    }else{
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Tela.imprimirPeca(tab.peca(i,j));
                    Console.BackgroundColor = fundoOriginal;
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez(){
            string s = Console.ReadLine();
            char coluna = Convert.ToChar(s[0]);
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca){
            if (peca ==  null)
                System.Console.Write("-");
            else{
                if (peca.cor == Cor.Branca){
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }else{
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
            }
            Console.Write(" ");
        }
    }
}