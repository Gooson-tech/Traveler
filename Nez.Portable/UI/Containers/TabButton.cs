using System;
using Microsoft.Xna.Framework;

namespace Nez.UI
{
    public class TabButton : Table, IInputListener
    {
        public enum TabButtonState
        {
            Inactive,
            Active,
            Locked
        }

        private TabButtonState state = TabButtonState.Inactive;

        private Label text;
        private TabButtonStyle style;
        private string tabName;
        private Tab tab;

        public Action OnClick;

        public TabButton(Tab tab, TabButtonStyle style)
        {
            this.style = style;
            tabName = tab.TabName;
            this.tab = tab;
            Init();
        }

        private void Init()
        {
            SetTouchable(Touchable.Enabled);
            text = new Label(tabName, style.LabelStyle);
            Add(text).SetFillX().Pad(8);
            SetBackground(style.Inactive);
            PadTop(style.PaddingTop);
        }

        public string GetTabeName()
        {
            return tabName;
        }

        public Tab GetTab()
        {
            return tab;
        }

        public bool IsSwitchedOn()
        {
            return state == TabButtonState.Active;
        }

        public void Toggle()
        {
            if (state != TabButtonState.Locked)
            {
                if (state == TabButtonState.Active)
                {
                    state = TabButtonState.Inactive;
                    SetBackground(style.Inactive);
                }
                else
                {
                    state = TabButtonState.Active;
                    SetBackground(style.Active);
                }
            }
        }

        public void ToggleOff()
        {
            if (state != TabButtonState.Locked)
            {
                state = TabButtonState.Inactive;

                SetBackground(style.Inactive);
            }
        }

        public void ToggleOn()
        {
            if (state != TabButtonState.Locked)
            {
                state = TabButtonState.Active;

                SetBackground(style.Active);
            }
        }

        public void ToggleLock()
        {
            if (state != TabButtonState.Inactive)
            {
                if (state == TabButtonState.Active)
                {
                    state = TabButtonState.Locked;
                    SetBackground(style.Locked);
                }
                else
                {
                    state = TabButtonState.Active;
                    SetBackground(style.Active);
                }
            }
        }

        public void Unlock()
        {
            if (state == TabButtonState.Locked)
            {
                state = TabButtonState.Active;
                SetBackground(style.Active);
            }
        }

        void IInputListener.OnMouseEnter()
        {
            if (state == TabButtonState.Inactive)
            {
                SetBackground(style.Hover);
            }
        }

        void IInputListener.OnMouseExit()
        {
            if (state == TabButtonState.Inactive)
            {
                SetBackground(style.Inactive);
            }
        }

        bool IInputListener.OnLeftMousePressed(Vector2 mousePos)
        {
            return true;
        }

        bool IInputListener.OnRightMousePressed(Vector2 mousePos)
        {
            return false;
        }

        void IInputListener.OnMouseMoved(Vector2 mousePos)
        {
        }

        void IInputListener.OnLeftMouseUp(Vector2 mousePos)
        {
            OnClick?.Invoke();
        }

        void IInputListener.OnRightMouseUp(Vector2 mousePos)
        {
        }

        bool IInputListener.OnMouseScrolled(int mouseWheelDelta)
        {
            return true;
        }
    }
}