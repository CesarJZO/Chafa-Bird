using System;

namespace Core
{
    [Flags]
    public enum GameState
    {
        Tutorial = 1,
        Playing = 2,
        Paused = 4,
        GameOver = 8
    }
}
