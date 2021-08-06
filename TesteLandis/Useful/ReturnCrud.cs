using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLandis.Useful
{
    public class ReturnCrud
    {
        public ReturnCrud()
        {
            Success = false;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
