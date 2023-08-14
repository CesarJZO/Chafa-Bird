using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Management
{
    public sealed class UIManager : MonoBehaviour
    {
        public static event Action<GameObject> SelectedChanged;

        private static GameObject _lastSelectedObject;

        public static GameObject LastSelectedObject
        {
            get => _lastSelectedObject;
            set
            {
                if (_lastSelectedObject == value) return;
                _lastSelectedObject = value;
                SelectedChanged?.Invoke(value);
            }
        }

        public static GameObject CurrentSelectedObject
        {
            get => EventSystem.current.currentSelectedGameObject;
            set
            {
                if (EventSystem.current.currentSelectedGameObject == value) return;
                EventSystem.current.SetSelectedGameObject(value);
                SelectedChanged?.Invoke(value);
            }
        }

        private void Awake()
        {
            UIInput.NavigatePerformed += OnNavigatePerformed;
            UIInput.SubmitPerformed += OnSubmitPerformed;
        }

        private void OnDestroy()
        {
            UIInput.NavigatePerformed -= OnNavigatePerformed;
            UIInput.SubmitPerformed -= OnSubmitPerformed;
        }


        private void OnNavigatePerformed(InputAction.CallbackContext context)
        {
            CurrentSelectedObject = LastSelectedObject;
        }

        private void OnSubmitPerformed(InputAction.CallbackContext context)
        {
            if (CurrentSelectedObject) return;

            if (LastSelectedObject.TryGetComponent(out Button button))
                button.onClick?.Invoke();
        }
    }
}
