using Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public sealed class ButtonAudio : MonoBehaviour, ISelectHandler, IPointerEnterHandler
    {
        public void OnSelect(BaseEventData eventData)
        {
            if (UIAudioManager.Instance)
                UIAudioManager.Instance.PlaySelect();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (UIAudioManager.Instance)
                UIAudioManager.Instance.PlaySelect();
        }
    }
}
