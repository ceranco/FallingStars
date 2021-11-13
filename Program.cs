using System;

namespace FallingStars
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new FallingStarsGame())
                game.Run();
        }
    }
}
