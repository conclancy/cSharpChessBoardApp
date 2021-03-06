﻿using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);

        static void Main(string[] args)
        {
            // show an empty board
            printBoard(myBoard);

            while (true)
            {
                // prompt for an x and y coordinate
                Cell currentCell = setCurrentCell();
                currentCell.CurrentlyOccupied = true;

                // calculate all legal moves for the piece 
                myBoard.MarkNextLegalMoves(currentCell, "Knight");

                // print new board.  Use X for occupied cell, + for legal move, _ for empty cell
                printBoard(myBoard);

                // Ask player if they want to play again
                Console.WriteLine("Play Again? [Y or N]");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

        }

        private static Cell setCurrentCell()
        {
            // ask user for x and y coordinate; return cell location
            int currentRow = validateCellInput("row");
            int currentColumn = validateCellInput("column");

            //Console.WriteLine("Enter the current column number");
            //int currentColumn = int.Parse(Console.ReadLine());

            myBoard.theGrid[currentRow, currentColumn].CurrentlyOccupied = true;
            return myBoard.theGrid[currentRow, currentColumn];
        }

        private static int validateCellInput(string vector)
        {  
            string vectorMessage = String.Format("Enter the current {0} number", vector);
            int vectorNumber = -1;
            while (vectorNumber < 0 || vectorNumber >= myBoard.Size)
            {
                int number; 
                string errorMessage = String.Format("Please enter a {0} number between 0 and 7", vector);

                Console.WriteLine(vectorMessage);
                string input = Console.ReadLine();

                if(!int.TryParse(input, out number))
                {
                   vectorMessage = errorMessage;
                   continue;
                }

                vectorNumber = Int32.Parse(input);

                if(vectorNumber < 0 || vectorNumber >= myBoard.Size)
                {
                    vectorMessage = errorMessage;
                    continue;
                }

            }
            return vectorNumber;
        }

        private static void printBoard(Board myBoard)
        {
            // print the chess board to the console.  Use X for occupied cell, + for legal move, _ for empty cell 
            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write("| X ");
                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write("| + ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("+---+---+---+---+---+---+---+---+");
            // Console.WriteLine("============");
        }
    }
}
