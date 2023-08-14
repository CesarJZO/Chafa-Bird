using Core;
using UnityEngine;

namespace Management
{
    public sealed class SceneLoader : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float delay;
        [SerializeField] private GameScene scene;

        public void LoadScene()
        {
            Invoke(nameof(LoadSceneWithDelay), delay);
        }

        private void LoadSceneWithDelay()
        {
            SceneManager.LoadScene(scene);
        }
    }
}
