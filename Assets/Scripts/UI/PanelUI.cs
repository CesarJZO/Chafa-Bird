using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class PanelUI : MonoBehaviour
    {
        public abstract event Action OnShow;
        public abstract event Action OnHide;
        public virtual event Action<Button> OnButtonClick;

        public abstract void Show();
        public abstract void Hide();

        protected void InvokeOnButtonClick(Button button)
        {
            OnButtonClick?.Invoke(button);
        }
    }
}
