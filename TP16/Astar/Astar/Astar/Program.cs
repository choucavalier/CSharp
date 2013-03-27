using System;

namespace Astar
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (Application game = new Application())
            {
                game.Run();
            }
        }
    }
#endif
}

