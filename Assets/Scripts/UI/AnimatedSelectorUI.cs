using Management;
using UnityEngine;

namespace UI
{
    public sealed class AnimatedSelectorUI : MonoBehaviour
    {
        [SerializeField] private Vector2 offset;
        [SerializeField] private float baseScale;

        [SerializeField] private float transitionSpeed;
        [SerializeField] private float scaleSpeed;
        [SerializeField] private float amplitude;

        private RectTransform _rectTransform;
        private RectTransform _targetTransform;

        private void Awake()
        {
            UIManager.SelectedChanged += OnSelectedChanged;
            _targetTransform = _rectTransform = GetComponent<RectTransform>();
        }

        private void OnDestroy()
        {
            UIManager.SelectedChanged -= OnSelectedChanged;
        }

        private void OnSelectedChanged(GameObject selectedObject)
        {
            if (!selectedObject) return;
            var selectedTransform = selectedObject.GetComponent<RectTransform>();

            if (!selectedTransform) return;
            _targetTransform = selectedTransform;
        }

        private void Update()
        {
            _rectTransform.position = Vector3.Lerp(
                _rectTransform.position, _targetTransform.position,
                transitionSpeed * Time.unscaledDeltaTime
            );
            _rectTransform.sizeDelta = Vector2.Lerp(
                _rectTransform.sizeDelta, _targetTransform.sizeDelta + offset,
                transitionSpeed * Time.unscaledDeltaTime
            );
            _rectTransform.localScale = Vector3.one * (baseScale + Mathf.Sin(Time.unscaledTime * scaleSpeed) * amplitude);
        }
    }
}
