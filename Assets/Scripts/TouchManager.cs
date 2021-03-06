using UnityEngine;

namespace Assets.Scripts {
    public class TouchManager : MonoBehaviour {
        public static TouchManager Instance { get => _instance; }
        private static TouchManager _instance;

        public InputLayer inputLayer;
        public void Awake() {
            if(_instance != null) {
                Destroy(this);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(this);
        }

        public void Update() {
            if(Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                switch(touch.phase) {
                    case TouchPhase.Began:
                        inputLayer.RaiseTouchBegan(touch);
                        break;
                    case TouchPhase.Moved:
                        inputLayer.RaiseTouchMoved(touch);
                        break;
                    case TouchPhase.Ended:
                        inputLayer.RaiseTouchEnd(touch);
                        break;
                }
            }
        }
    }

}
