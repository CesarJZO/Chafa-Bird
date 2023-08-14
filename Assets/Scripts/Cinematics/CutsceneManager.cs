using UnityEngine;

namespace Cinematics
{
    public sealed class CutsceneManager : MonoBehaviour
    {
        [SerializeField] private Cutscene cutscene;

        public void Play()
        {
            cutscene.gameObject.SetActive(true);
        }

        public void Skip()
        {
            cutscene.Skip();
        }

        public void Stop()
        {
            cutscene.Stop();
        }
    }
}
