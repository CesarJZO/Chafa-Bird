using System;

namespace Core
{
    [Flags]
    public enum GameState
    {
        SceneIntro = 1,
        Playing = 2,
        Paused = 4,
        SceneOutro = 8,
        Cutscene = 16,
        PlayerDead = 32,
    }
}
