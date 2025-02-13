// See https://aka.ms/new-console-template for more information
using Estudo_Extra_Sudoku_Resolver.Classe;

Console.WriteLine("Iniciando Sudoku");

var sudoku = new Sudoku();

MostrarSudoku(sudoku);
Console.ReadLine();
sudoku.Resolver();
//Console.Clear();
Console.WriteLine("Solução: ");
MostrarSudoku(sudoku);
Console.ReadLine();


static void MostrarSudoku(Sudoku sudoku)
{
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            if (sudoku.SA[i, j].Valor == 0) Console.Write(" [ ] ");
            else Console.Write($" [{sudoku.SA[i, j].Valor}] ");

            if (j == 2 || j == 5) Console.Write("|");

            if (j == 8) Console.WriteLine();
        }
        if (i == 2 || i == 5) Console.WriteLine();
    }
}