using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {

    class Tela {

        public static void imprimirTabuleiro(Tabuleiro tab) {

            for(int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for(int j = 0; j < tab.colunas; j++) {
                        imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                    if(posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }


        public static PosicaoXadrez lerPosicaoXadrez() {
            string[] posicoesA = new string[] { "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8" };
            string[] posicoesB = new string[] { "b1", "b2", "b3", "b4", "b5", "b6", "b7", "b8" };
            string[] posicoesC = new string[] { "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8" };
            string[] posicoesD = new string[] { "d1", "d2", "d3", "d4", "d5", "d6", "d7", "d8" };
            string[] posicoesE = new string[] { "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8" };
            string[] posicoesF = new string[] { "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8" };
            string[] posicoesG = new string[] { "g1", "g2", "g3", "g4", "g5", "g6", "g7", "g8" };
            string[] posicoesH = new string[] { "h1", "h2", "h3", "h4", "h5", "h6", "h7", "h8" };

            string s = Console.ReadLine();
            if (s == "" || s.Contains("'") || s.Contains("!") || s.Contains("@") || s.Contains("¹") 
                || s.Contains("²") || s.Contains("³") || s.Contains("£") || s.Contains("#") || s.Contains("$")
                 || s.Contains("¢") || s.Contains("%") || s.Contains("¨") || s.Contains("¬") || s.Contains("&")
                  || s.Contains("*") || s.Contains("(") || s.Contains(")") || s.Contains("_") || s.Contains("-")
                   || s.Contains("§") || s.Contains("+") || s.Contains("=") || s.Contains("|") || s.Contains("'\'")
                    || s.Contains("<") || s.Contains(",") || s.Contains(">") || s.Contains(".") || s.Contains(":")
                     || s.Contains(";") || s.Contains("ç") || s.Contains("Ç") || s.Contains("^") || s.Contains("~")
                      || s.Contains("}") || s.Contains("]") || s.Contains("º") || s.Contains("{") || s.Contains("[")
                       || s.Contains("ª") || s.Contains("´") || s.Contains("`") || s.Contains("/") || s.Contains("°")
                        || s.Contains("?")) {
                throw new TabuleiroException("Digite Uma Posição Válida!");
            } else {
                char coluna = s[0];
                int linha = int.Parse(s[1] + " ");
                return new PosicaoXadrez(coluna, linha);

            }
        }

        public static void imprimirPeca(Peca peca) {

            if (peca == null) {
                Console.Write("- ");
            } else {
                


                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static void imprimirPartida(PartidaDeXadrez partida) {
            Tela.imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);

            if (!partida.terminada) {

                Console.WriteLine("Aguardando Jogada: " + partida.jogadorAtual);

                if (partida.xeque) {
                    Console.WriteLine("XEQUE!");
                }
            } else {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjuntos(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjuntos(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjuntos(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach (Peca x in conjunto) {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
    }
}
