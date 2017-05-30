using System;
using System.Collections;
using System.IO;
using System.Text;

namespace puzzle
{
    public class GameBoard
    {
        private static ArrayList moveList;
        private static int solutions = 0;
        private StringBuilder boardState;
        private int pegs;
        private string gameMoves;

        static GameBoard()
        {
            moveList = new ArrayList(36);
            moveList.Add(new Move(0, 1, 3));
            moveList.Add(new Move(0, 2, 5));
            moveList.Add(new Move(1, 3, 6));
            moveList.Add(new Move(1, 4, 8));
            moveList.Add(new Move(2, 4, 7));
            moveList.Add(new Move(2, 5, 9));
            moveList.Add(new Move(3, 1, 0));
            moveList.Add(new Move(3, 4, 5));
            moveList.Add(new Move(3, 6, 10));
            moveList.Add(new Move(3, 7, 12));
            moveList.Add(new Move(4, 7, 11));
            moveList.Add(new Move(4, 8, 13));
            moveList.Add(new Move(5, 2, 0));
            moveList.Add(new Move(5, 4, 3));
            moveList.Add(new Move(5, 8, 12));
            moveList.Add(new Move(5, 9, 14));
            moveList.Add(new Move(6, 3, 1));
            moveList.Add(new Move(6, 7, 8));
            moveList.Add(new Move(7, 4, 2));
            moveList.Add(new Move(7, 8, 9));
            moveList.Add(new Move(8, 4, 1));
            moveList.Add(new Move(8, 7, 6));
            moveList.Add(new Move(9, 5, 2));
            moveList.Add(new Move(9, 8, 7));
            moveList.Add(new Move(10, 6, 3));
            moveList.Add(new Move(10, 11, 12));
            moveList.Add(new Move(11, 7, 4));
            moveList.Add(new Move(11, 12, 13));
            moveList.Add(new Move(12, 7, 3));
            moveList.Add(new Move(12, 8, 5));
            moveList.Add(new Move(12, 11, 10));
            moveList.Add(new Move(12, 13, 14));
            moveList.Add(new Move(13, 8, 4));
            moveList.Add(new Move(13, 12, 11));
            moveList.Add(new Move(14, 9, 5));
            moveList.Add(new Move(14, 13, 12));
        }

        public GameBoard(StringBuilder boardState, string gameMoves)
        {
            this.boardState = boardState;
            pegs = 0;
            for (int i = 0; i < this.boardState.Length; i++)
            {
                switch (this.boardState[i])
                {
                    case 'X':
                        pegs++;
                        break;
                    default:
                        this.boardState[i] = 'O';
                        break;
                }
            }
            this.gameMoves = gameMoves;
        }

        public string Search()
        {
            if (pegs == 1)
            {
                return gameMoves;
            }
            else
            {
                for (int i = 0; i < moveList.Count; i++)
                {
                    Move m = (Move)moveList[i];
                    StringBuilder s = new StringBuilder(boardState.ToString(), 16);
                    if (m.IsPossible(s))
                    {
                        m.MakeMove(ref s);
                        GameBoard newBoard = new GameBoard(s, this.gameMoves + m.ToString());
                        string solution = newBoard.Search();
                        if (solution != "")
                            ShowSolution(solution);
                    }
                }
                return "";
            }
        }

        private void ShowSolution(string solution)
        {
            string[] moves = solution.Split(' ');
            Console.Write("{0,6} : ", ++solutions);
            for (int i = 0; i < moves.Length; i++)
                if (moves[i].Trim().Length != 0)
                    System.Console.Write("{0} ", moves[i]);
            System.Console.WriteLine();
        }
    }
}
