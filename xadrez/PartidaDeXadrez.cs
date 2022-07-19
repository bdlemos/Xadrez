using System;
using tabuleiro;

namespace xadrez{
    class PartidaDeXadrez{
        public Tabuleiro tab{ get; private set;}
        public int turno { get; private set;}
        public Cor jogadorAtual { get; private set;}
        public bool terminada{ get; set; } 

        //CONSTRUCTOR
        public PartidaDeXadrez(){
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }
        //METHODS
        public void executaMovimento(Posicao origem, Posicao destino){
            Peca p = tab.retirarPeca(origem);
            p.incrimentarQteMovimentos();
            Peca? pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p,destino);

        }

        public void realizaJogada(Posicao origem, Posicao destino){
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao pos){
            if (tab.peca(pos) == null){
                throw new TabuleiroException("Não existe peca na posicao de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor){
                throw new TabuleiroException("A peca de origem escolhida nao e sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()){
                throw new TabuleiroException("Nao existe movimento possivel para essa peca escolhida");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino){
            if(!tab.peca(origem).podeMoverPara(destino)){
                throw new TabuleiroException("Posicao de destino inválida!");
            }
        }

        private void mudaJogador(){
            if (jogadorAtual == Cor.Branca)
                jogadorAtual = Cor.Preta;
            else
                jogadorAtual = Cor.Branca;
        }

        private void colocarPecas(){
            tab.colocarPeca(new Torre(tab, Cor.Branca),new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca),new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca),new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca),new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca),new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca),new PosicaoXadrez('d', 1).toPosicao());
            
            
            tab.colocarPeca(new Torre(tab, Cor.Preta),new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta),new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta),new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta),new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta),new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta),new PosicaoXadrez('d', 8).toPosicao());
        }
    }
    
}