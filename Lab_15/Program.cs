using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    internal class Program
    {
        int N = 4;

        void printFinal(int[,] board)
        {
            Console.WriteLine("-=QueenInator=-");
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(" " + board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /* Функція, яка перевіряє чи можливо помістити королеву на board[row,col]. Note that this
        function is called when "col" queens are already
        placeed in columns from 0 to col -1. So we need
        to check only left side for attacking queens */
        bool QueenSafeChecker(int[,] board, int row, int col)
        {
            int i, j;

            /* Прямі Лінії */
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                {
                    return false;
                }
            }

            /* Одна Діагональ (не берем всі, бо через розставлення по бокам є лише 2 діагоналі і 3 сторони) */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            /* Друга Діагональ (не берем всі, бо через розставлення по бокам є лише 2 діагоналі і 3 сторони) */
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        /* Рекурсивна Функція, Для Того Щоб Перевіряти Проблеми З Королевами*/
        bool QueenPositionSearcher(int[,] board, int col)
        {
            /* Якщо всі королеви розставлені, тоді все добре */
            if (col >= N)
            {
                return true;
            }

            /* Берем одну колонку, і пробуєм розставляти королев в ній */
            for (int i = 0; i < N; i++)
            {
                /* Перевірка, чи можна поставити королеву на board[i,col] */
                if (QueenSafeChecker(board, i, col))
                {
                    /* Поставити королеву на board[i,col] */
                    board[i, col] = 1;

                    /* Рекурсія, щоб розставити всіх інших королев */
                    if (QueenPositionSearcher(board, col + 1) == true)
                    {
                        return true;
                    }

                    /* Якщо постановка королеви на board[i,col] не призводить до рішення то забираємо фігуру назад */
                    board[i, col] = 0;
                }
            }

            /* Якщо королеву не можна поставити ніде з рядків колонки, яку ми берем, то вертаєм неправильно */
            return false;
        }

        /* Програма вирішує завдання з N королевами за допомогою "проб і помилок". Програма в основному побудована на 
         * функції QueenPositionSearcher() яка видає можливі позиції королев. Ця функція вертає хибність, 
         * коли королев розташувати в даних умовах не можливо, або вертає істину і рішення, коли воно існує. 
         * Рішень може бути більше ніж 1, але ця програма показує тільки 1 рішення із всіх можливих 
         */
        bool QueenPositionResult()
        {
            int[,] board = {{ 0, 0, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }};

            if (QueenPositionSearcher(board, 0) == false)
            {
                Console.Write("There is no Result. Can't solve this");
                return false;
            }

            printFinal(board);
            return true;
        }

        public static void Main(String[] args)
        {
            Program Queen = new Program();
            Queen.QueenPositionResult();
            Console.ReadKey();
        }
    }
}
