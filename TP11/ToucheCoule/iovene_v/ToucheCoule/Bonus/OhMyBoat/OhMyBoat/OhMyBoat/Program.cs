using System;

namespace OhMyBoat
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Application())
            {
                game.Run();
            }
        }
    }
#endif
}

