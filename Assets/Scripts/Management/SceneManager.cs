using Core;

namespace Management
{
    public static class SceneManager
    {
        public static void LoadScene(GameScene scene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
        }
    }
}
