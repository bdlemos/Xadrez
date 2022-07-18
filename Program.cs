using System;
using tabuleiro;

namespace xadrez{
    class Program{
        static void Main(){
            try{
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.terminada){
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    
                    System.Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    System.Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    
                    partida.executaMovimento(origem, destino);
                }

            }
            catch(TabuleiroException e){
                System.Console.WriteLine(e.Message);
            }
        }
    }
}