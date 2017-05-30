using System;
using System.Text;

namespace puzzle
{
    public class Move
    {
        int pegFrom, pegOver, pegTo;

        public Move(int pegFrom, int pegOver, int pegTo)
        {
            this.pegFrom = pegFrom;
            this.pegOver = pegOver;
            this.pegTo = pegTo;
        }
        public bool IsPossible(StringBuilder s)
        {
            return (s[pegFrom] == 'X' && s[pegOver] == 'X' && s[pegTo] == 'O');
        }
        public void MakeMove(ref StringBuilder s)
        {
            s[pegFrom] = s[pegOver] = 'O';
            s[pegTo] = 'X';
        }
        public override string ToString()
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O' };
            return (letters[pegFrom]) + "/" + (letters[pegOver]) + " ";
        }
    }
}
