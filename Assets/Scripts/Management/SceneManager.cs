using Core;
using UnityEngine;

namespace Management
{
    public sealed class SceneManager : MonoBehaviour
    {
        public static void LoadScene(GameScene scene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
        }


    }
}
