using System;

namespace FNA_Snowfall_Starostin
{
    static class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        static void Main(string[] args)
        {
            using (var game = new Snow())
            {
                game.Run();
            }
        }
    }
}
