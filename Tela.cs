using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez{
    static class Tela{
        public static void imprimirPartida(PartidaDeXadrez partida){
            Tela.imprimirTabuleiro(partida.tab);
            System.Console.WriteLine();
            imprimirPecasCapturadas(partida);
            System.Console.WriteLine();
            System.Console.WriteLine("Turno: " + partida.turno);
            if(!partida.terminada){
                System.Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque){
                    System.Console.WriteLine("XEQUE!");
                }
            }else{
                System.Console.WriteLine("XEQUEMATE!");
                System.Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida){
            Console.WriteLine("Pecas capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }
        public static void imprimirConjunto(HashSet<Peca> conjunto){
            System.Console.Write("[");
            foreach (Peca x  in conjunto){
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }

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