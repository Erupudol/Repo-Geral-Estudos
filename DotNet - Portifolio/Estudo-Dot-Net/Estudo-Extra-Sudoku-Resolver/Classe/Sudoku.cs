using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Estudo_Extra_Sudoku_Resolver.Classe
{
    public class Sudoku
    {
        public int[] numerosDiponiveis = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public Cell[,] SA { get; set; }

        public Sudoku()
        {
            SA = new Cell[9, 9];

            SA[0, 0] = new Cell() { Valor = 9 }; SA[0, 1] = new Cell() { Valor = 0 }; SA[0, 2] = new Cell() { Valor = 0 };      SA[0, 3] = new Cell() { Valor = 8 }; SA[0, 4] = new Cell() { Valor = 4 }; SA[0, 5] = new Cell() { Valor = 1 };      SA[0, 6] = new Cell() { Valor = 3 }; SA[0, 7] = new Cell() { Valor = 0 }; SA[0, 8] = new Cell() { Valor = 0 };
            SA[1, 0] = new Cell() { Valor = 0 }; SA[1, 1] = new Cell() { Valor = 0 }; SA[1, 2] = new Cell() { Valor = 1 };      SA[1, 3] = new Cell() { Valor = 9 }; SA[1, 4] = new Cell() { Valor = 0 }; SA[1, 5] = new Cell() { Valor = 0 };      SA[1, 6] = new Cell() { Valor = 4 }; SA[1, 7] = new Cell() { Valor = 2 }; SA[1, 8] = new Cell() { Valor = 0 };
            SA[2, 0] = new Cell() { Valor = 0 }; SA[2, 1] = new Cell() { Valor = 0 }; SA[2, 2] = new Cell() { Valor = 0 };      SA[2, 3] = new Cell() { Valor = 2 }; SA[2, 4] = new Cell() { Valor = 0 }; SA[2, 5] = new Cell() { Valor = 0 };      SA[2, 6] = new Cell() { Valor = 0 }; SA[2, 7] = new Cell() { Valor = 1 }; SA[2, 8] = new Cell() { Valor = 0 };

            SA[3, 0] = new Cell() { Valor = 8 }; SA[3, 1] = new Cell() { Valor = 7 }; SA[3, 2] = new Cell() { Valor = 0 };      SA[3, 3] = new Cell() { Valor = 1 }; SA[3, 4] = new Cell() { Valor = 0 }; SA[3, 5] = new Cell() { Valor = 0 };      SA[3, 6] = new Cell() { Valor = 5 }; SA[3, 7] = new Cell() { Valor = 4 }; SA[3, 8] = new Cell() { Valor = 0 };
            SA[4, 0] = new Cell() { Valor = 1 }; SA[4, 1] = new Cell() { Valor = 5 }; SA[4, 2] = new Cell() { Valor = 0 };      SA[4, 3] = new Cell() { Valor = 3 }; SA[4, 4] = new Cell() { Valor = 6 }; SA[4, 5] = new Cell() { Valor = 0 };      SA[4, 6] = new Cell() { Valor = 0 }; SA[4, 7] = new Cell() { Valor = 0 }; SA[4, 8] = new Cell() { Valor = 2 };
            SA[5, 0] = new Cell() { Valor = 2 }; SA[5, 1] = new Cell() { Valor = 0 }; SA[5, 2] = new Cell() { Valor = 0 };      SA[5, 3] = new Cell() { Valor = 0 }; SA[5, 4] = new Cell() { Valor = 0 }; SA[5, 5] = new Cell() { Valor = 0 };      SA[5, 6] = new Cell() { Valor = 7 }; SA[5, 7] = new Cell() { Valor = 6 }; SA[5, 8] = new Cell() { Valor = 0 };

            SA[6, 0] = new Cell() { Valor = 7 }; SA[6, 1] = new Cell() { Valor = 2 }; SA[6, 2] = new Cell() { Valor = 0 };      SA[6, 3] = new Cell() { Valor = 0 }; SA[6, 4] = new Cell() { Valor = 0 }; SA[6, 5] = new Cell() { Valor = 5 };      SA[6, 6] = new Cell() { Valor = 1 }; SA[6, 7] = new Cell() { Valor = 9 }; SA[6, 8] = new Cell() { Valor = 0 };
            SA[7, 0] = new Cell() { Valor = 6 }; SA[7, 1] = new Cell() { Valor = 3 }; SA[7, 2] = new Cell() { Valor = 0 };      SA[7, 3] = new Cell() { Valor = 0 }; SA[7, 4] = new Cell() { Valor = 0 }; SA[7, 5] = new Cell() { Valor = 0 };      SA[7, 6] = new Cell() { Valor = 2 }; SA[7, 7] = new Cell() { Valor = 0 }; SA[7, 8] = new Cell() { Valor = 7 };
            SA[8, 0] = new Cell() { Valor = 0 }; SA[8, 1] = new Cell() { Valor = 1 }; SA[8, 2] = new Cell() { Valor = 5 };      SA[8, 3] = new Cell() { Valor = 7 }; SA[8, 4] = new Cell() { Valor = 0 }; SA[8, 5] = new Cell() { Valor = 2 };      SA[8, 6] = new Cell() { Valor = 0 }; SA[8, 7] = new Cell() { Valor = 0 }; SA[8, 8] = new Cell() { Valor = 8 };


        }

        public void Resolver()
        {
            while(VerificarCellEmBranco())
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var cell = SA[i, j];
                        if (cell.Valor == 0)
                        {
                            var valoresDisponiveis = VerificarNumerosPossiveis(i, j);
                            if (valoresDisponiveis.Count() == 1) 
                            {
                                SA[i, j].Valor = valoresDisponiveis[0];
                                //Console.Clear();
                                //Console.WriteLine($"Valor unico encontrado para a celula[{i},{j}]");
                                //MostraSudoku();
                                //Console.ReadLine();
                            }
                            else SA[i, j].ValoresPossiveis = valoresDisponiveis;
                        }
                    }
                }
        }
        bool VerificarCellEmBranco()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    var cell = SA[i, j];
                    if (cell.Valor == 0)
                        return true;
                }
            return false; 
        }
                    
        int[] VerificarNumerosPossiveis(int i, int j)
        {
            var valores = numerosDiponiveis;

            //Validar Linhas:
            for (var l = 0; l < 9; l++)
                valores = valores.Where(v => v != SA[i, l].Valor).ToArray();

            //Validar Colunas
            for (var c = 0; c < 9; c++)
                valores = valores.Where(v => v != SA[c, j].Valor).ToArray();

            //Validar Quadrante
            var quadrante = GerarQuadrante(i, j);

            for (var qi = 0; qi < 3; qi++)
                for (var qj = 0; qj < 3; qj++)
                    valores = valores.Where(v => v != quadrante[qi, qj]).ToArray();


            return valores;

        }

        private int[,] GerarQuadrante(int i, int j)
        {
            var quadrante = new int[3, 3];
            if (i == 0 || i == 3 || i == 6)
            {
                if (j == 0 || j == 3 || j == 6)
                {
                    quadrante[0, 0] = SA[i, j].Valor;
                    quadrante[0, 1] = SA[i, j + 1].Valor;
                    quadrante[0, 2] = SA[i, j + 2].Valor;
                    quadrante[1, 0] = SA[i + 1, j].Valor;
                    quadrante[1, 1] = SA[i + 1, j + 1].Valor;
                    quadrante[1, 2] = SA[i + 1, j + 2].Valor;
                    quadrante[2, 0] = SA[i + 2, j].Valor;
                    quadrante[2, 1] = SA[i + 2, j + 1].Valor;
                    quadrante[2, 2] = SA[i + 2, j + 2].Valor;
                }
                if (j == 1 || j == 4 || j == 7)
                {
                    quadrante[0, 0] = SA[i, j - 1].Valor;
                    quadrante[0, 1] = SA[i, j].Valor;
                    quadrante[0, 2] = SA[i, j + 1].Valor;
                    quadrante[1, 0] = SA[i + 1, j - 1].Valor;
                    quadrante[1, 1] = SA[i + 1, j].Valor;
                    quadrante[1, 2] = SA[i + 1, j + 1].Valor;
                    quadrante[2, 0] = SA[i + 2, j - 1].Valor;
                    quadrante[2, 1] = SA[i + 2, j].Valor;
                    quadrante[2, 2] = SA[i + 2, j + 1].Valor;
                }
                if (j == 2 || j == 5 || j == 8)
                {
                    quadrante[0, 0] = SA[i, j - 2].Valor;
                    quadrante[0, 1] = SA[i, j - 1].Valor;
                    quadrante[0, 2] = SA[i, j].Valor;
                    quadrante[1, 0] = SA[i + 1, j - 2].Valor;
                    quadrante[1, 1] = SA[i + 1, j - 1].Valor;
                    quadrante[1, 2] = SA[i + 1, j].Valor;
                    quadrante[2, 0] = SA[i + 2, j - 2].Valor;
                    quadrante[2, 1] = SA[i + 2, j - 1].Valor;
                    quadrante[2, 2] = SA[i + 2, j].Valor;
                }
            }
            if (i == 1 || i == 4 || i == 7)
            {
                if (j == 0 || j == 3 || j == 6)
                {
                    quadrante[0, 0] = SA[i - 1, j].Valor;
                    quadrante[0, 1] = SA[i - 1, j + 1].Valor;
                    quadrante[0, 2] = SA[i - 1, j + 2].Valor;
                    quadrante[1, 0] = SA[i, j].Valor;
                    quadrante[1, 1] = SA[i, j + 1].Valor;
                    quadrante[1, 2] = SA[i, j + 2].Valor;
                    quadrante[2, 0] = SA[i + 1, j].Valor;
                    quadrante[2, 1] = SA[i + 1, j + 1].Valor;
                    quadrante[2, 2] = SA[i + 1, j + 2].Valor;
                }
                if (j == 1 || j == 4 || j == 7)
                {
                    quadrante[0, 0] = SA[i - 1, j - 1].Valor;
                    quadrante[0, 1] = SA[i - 1, j].Valor;
                    quadrante[0, 2] = SA[i - 1, j + 1].Valor;
                    quadrante[1, 0] = SA[i, j - 1].Valor;
                    quadrante[1, 1] = SA[i, j].Valor;
                    quadrante[1, 2] = SA[i, j + 1].Valor;
                    quadrante[2, 0] = SA[i + 1, j - 1].Valor;
                    quadrante[2, 1] = SA[i + 1, j].Valor;
                    quadrante[2, 2] = SA[i + 1, j + 1].Valor;
                }
                if (j == 2 || j == 5 || j == 8)
                {
                    quadrante[0, 0] = SA[i - 1, j - 2].Valor;
                    quadrante[0, 1] = SA[i - 1, j - 1].Valor;
                    quadrante[0, 2] = SA[i - 1, j].Valor;
                    quadrante[1, 0] = SA[i, j - 2].Valor;
                    quadrante[1, 1] = SA[i, j - 1].Valor;
                    quadrante[1, 2] = SA[i, j].Valor;
                    quadrante[2, 0] = SA[i + 1, j - 2].Valor;
                    quadrante[2, 1] = SA[i + 1, j - 1].Valor;
                    quadrante[2, 2] = SA[i + 1, j].Valor;
                }
            }
            if (i == 2 || i == 5 || i == 8)
            {
                if (j == 0 || j == 3 || j == 6)
                {
                    quadrante[0, 0] = SA[i - 2, j].Valor;
                    quadrante[0, 1] = SA[i - 2, j + 1].Valor;
                    quadrante[0, 2] = SA[i - 2, j + 2].Valor;
                    quadrante[1, 0] = SA[i - 1, j].Valor;
                    quadrante[1, 1] = SA[i - 1, j + 1].Valor;
                    quadrante[1, 2] = SA[i - 1, j + 2].Valor;
                    quadrante[2, 0] = SA[i, j].Valor;
                    quadrante[2, 1] = SA[i, j + 1].Valor;
                    quadrante[2, 2] = SA[i, j + 2].Valor;
                }
                if (j == 1 || j == 4 || j == 7)
                {
                    quadrante[0, 0] = SA[i - 2, j - 1].Valor;
                    quadrante[0, 1] = SA[i - 2, j].Valor;
                    quadrante[0, 2] = SA[i - 2, j + 1].Valor;
                    quadrante[1, 0] = SA[i - 1, j - 1].Valor;
                    quadrante[1, 1] = SA[i - 1, j].Valor;
                    quadrante[1, 2] = SA[i - 1, j + 1].Valor;
                    quadrante[2, 0] = SA[i, j - 1].Valor;
                    quadrante[2, 1] = SA[i, j].Valor;
                    quadrante[2, 2] = SA[i, j + 1].Valor;
                }
                if (j == 2 || j == 5 || j == 8)
                {
                    quadrante[0, 0] = SA[i - 2, j - 2].Valor;
                    quadrante[0, 1] = SA[i - 2, j - 1].Valor;
                    quadrante[0, 2] = SA[i - 2, j].Valor;
                    quadrante[1, 0] = SA[i - 1, j - 2].Valor;
                    quadrante[1, 1] = SA[i - 1, j - 1].Valor;
                    quadrante[1, 2] = SA[i - 1, j].Valor;
                    quadrante[2, 0] = SA[i, j - 2].Valor;
                    quadrante[2, 1] = SA[i, j - 1].Valor;
                    quadrante[2, 2] = SA[i, j].Valor;
                }
            }

            //Console.WriteLine($"Quadrante Gerado pela Celula [{i}, {j}]");

            //for (int a = 0; a < 3; a++)
            //{
            //    for (int b = 0; b < 3; b++)
            //    {
            //        if (quadrante[a, b] == 0) Console.Write(" [ ] ");
            //        else Console.Write($" [{quadrante[a, b]}] ");

            //        if (b == 2 || b == 5) Console.Write("|");

            //        if (b == 2) Console.WriteLine();
            //    }
            //}
            //Console.ReadLine();
            return quadrante;
        }

        void MostraSudoku()
        {
            for (int l = 0; l < 9; l++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (SA[l, c].Valor == 0) Console.Write(" [ ] ");
                    else Console.Write($" [{SA[l, c].Valor}] ");

                    if (c == 2 || c == 5) Console.Write("|");

                    if (c == 8) Console.WriteLine();
                }
                if (l == 2 || l == 5) Console.WriteLine();
            }
        }
    }

    public class Cell
    {
        public int Valor;
        public int[] ValoresPossiveis;
    }
}
