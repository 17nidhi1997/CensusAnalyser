using System;
using System.Collections.Generic;
using System.Text;

namespace CensersAnaliserProblem
{
    public enum ExceptionType
    {
        CSVFILE_IS_EMPTY
    }

    public class CSVException : Exception
    {

        public string mgs;
        public CSVException(string message)
        {
            this.mgs = message;
        }
    }

}
