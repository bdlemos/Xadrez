using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez{
    class PartidaDeXadrez{
        public Tabuleiro tab{ get; private set;}
        public int turno { get; private set;}
        public Cor jogadorAtual { get; private set;}
        public bool terminada{ get; set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas; 

        //CONSTRUCTOR
        public PartidaDeXadrez(){
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }
        //METHODS
        public void executaMovimento(Posicao origem, Posicao destino){
            Peca p = tab.retirarPeca(origem);
            p.incrimentarQteMovimentos();
            Peca? pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p,destino);
            if(pecaCapturada != null){
                capturadas.Add(pecaCapturada);
            }
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

        public HashSet<Peca> pecasCapturadas(Cor cor){
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas){
                if (x.cor == cor)
                    aux.Add(x);
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor){
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas){
                if (x.cor == cor)
                    aux.Add(x);
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca){
            tab.colocarPeca(peca, new PosicaoXadrez(coluna,linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas(){
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));
            
            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
            
        }
    }
    
}