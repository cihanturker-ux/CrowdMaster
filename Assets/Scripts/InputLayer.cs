using System.Collections;
using UnityEngine;

namespace Assets.Scripts {
    [CreateAssetMenu(menuName = "InputLayer")]
    public class InputLayer : ScriptableObject {
        public bool Touching { get; private set; }
        public Vector2 LastTouchPosition { get; private set; }

        public delegate void TouchEvent(Touch touch);
        public event TouchEvent OnTouchBegan;
        public event TouchEvent OnTouchMoved;
        public event TouchEvent OnTouchEnded;

        public void RaiseTouchBegan(Touch touch) {
            OnTouchBegan?.Invoke(touch);
            LastTouchPosition = touch.position;
            Touching = true;
        }

        public void RaiseTouchEnd(Touch touch) {
            this.Touching = false;
            LastTouchPosition = touch.position;
            OnTouchEnded?.Invoke(touch);
        }

        public void RaiseTouchMoved(Touch touch) {
            LastTouchPosition = touch.position;
            OnTouchMoved?.Invoke(touch);
        }
    }
}