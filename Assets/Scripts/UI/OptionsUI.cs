using System;

namespace UI
{
    public sealed class OptionsUI : PanelUI
    {
        public override event Action OnShow;
        public override event Action OnHide;

        public override void Show()
        {
            gameObject.SetActive(true);
            OnShow?.Invoke();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
    }
}
