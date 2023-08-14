using Management;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI
{
    public sealed class SelectableHandlerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        public event UnityAction PointerEntered
        {
            add => onPointerEnter.AddListener(value);
            remove => onPointerEnter.RemoveListener(value);
        }

        public event UnityAction PointerExited
        {
            add => onPointerExit.AddListener(value);
            remove => onPointerExit.RemoveListener(value);
        }

        public event UnityAction Selected
        {
            add => onSelect.AddListener(value);
            remove => onSelect.RemoveListener(value);
        }

        public event UnityAction Deselected
        {
            add => onDeselect.AddListener(value);
            remove => onDeselect.RemoveListener(value);
        }

        [SerializeField] public UnityEvent onPointerEnter;
        [SerializeField] public UnityEvent onPointerExit;
        [SerializeField] public UnityEvent onSelect;
        [SerializeField] public UnityEvent onDeselect;

        public void OnPointerEnter(PointerEventData eventData)
        {
            eventData.selectedObject = gameObject;
            onPointerEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            eventData.selectedObject = null;
            onPointerExit?.Invoke();
        }

        public void OnSelect(BaseEventData eventData)
        {
            UIManager.LastSelectedObject = gameObject;
            onSelect?.Invoke();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            onDeselect?.Invoke();
        }
    }
}
