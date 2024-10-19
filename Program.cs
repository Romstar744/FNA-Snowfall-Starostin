using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FNA_Snowfall_Starostin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Snow game = new Snow())
            {
                game.Run();
            }
        }
    }
}
