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
            moveList.Add(new Move(00, 01, 03));
            moveList.Add(new Move(00, 02, 05));
            moveList.Add(new Move(01, 03, 06));
            moveList.Add(new Move(01, 04, 08));
            moveList.Add(new Move(02, 04, 07));
            moveList.Add(new Move(02, 05, 09));
            moveList.Add(new Move(03, 01, 00));
            moveList.Add(new Move(03, 04, 05));
            moveList.Add(new Move(03, 06, 10));
            moveList.Add(new Move(03, 07, 12));
            moveList.Add(new Move(04, 07, 11));
            moveList.Add(new Move(04, 08, 13));
            moveList.Add(new Move(05, 02, 00));
            moveList.Add(new Move(05, 04, 03));
            moveList.Add(new Move(05, 08, 12));
            moveList.Add(new Move(05, 09, 14));
            moveList.Add(new Move(06, 03, 01));
            moveList.Add(new Move(06, 07, 08));
            moveList.Add(new Move(07, 04, 02));
            moveList.Add(new Move(07, 08, 09));
            moveList.Add(new Move(08, 04, 01));
            moveList.Add(new Move(08, 07, 06));
            moveList.Add(new Move(09, 05, 02));
            moveList.Add(new Move(09, 08, 07));
            moveList.Add(new Move(10, 06, 03));
            moveList.Add(new Move(10, 11, 12));
            moveList.Add(new Move(11, 07, 04));
            moveList.Add(new Move(11, 12, 13));
            moveList.Add(new Move(12, 07, 03));
            moveList.Add(new Move(12, 08, 05));
            moveList.Add(new Move(12, 11, 10));
            moveList.Add(new Move(12, 13, 14));
            moveList.Add(new Move(13, 08, 04));
            moveList.Add(new Move(13, 12, 11));
            moveList.Add(new Move(14, 09, 05));
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
