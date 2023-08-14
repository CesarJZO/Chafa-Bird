using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class ProgressBarUI : MonoBehaviour
    {
        [SerializeField] private GameObject hasProgress;
        [SerializeField] private Image progressBarImage;

        private void Start()
        {
            if (!hasProgress) return;
            if (!hasProgress.TryGetComponent(out IHasProgress progress)) return;
            progress.ProgressUpdated += OnProgressUpdated;
            OnProgressUpdated(progress.ProgressNormalized);
        }

        private void OnDestroy()
        {
            if (!hasProgress) return;
            if (!hasProgress.TryGetComponent(out IHasProgress progress)) return;
            progress.ProgressUpdated -= OnProgressUpdated;
        }

        private void OnProgressUpdated(float progress)
        {
            progressBarImage.fillAmount = progress;
        }
    }
}
