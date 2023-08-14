using Input;
using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class PromptUI : MonoBehaviour
    {
        [SerializeField] private GameInputAction gameInputAction;
        [SerializeField] private string message;
        [SerializeField] private TextMeshProUGUI text;

        private void Awake()
        {
            GameInput.ControlSchemeChanged += OnControlSchemeChanged;
        }

        private void Start()
        {
            UpdateText();
        }

        private void OnDestroy()
        {
            GameInput.ControlSchemeChanged -= OnControlSchemeChanged;
        }

        private void OnControlSchemeChanged(ControlScheme controlScheme)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            string inputBinding = GameInput.GetBindingForAction(gameInputAction);
            text.text = string.Format(message, inputBinding);
        }
    }
}
