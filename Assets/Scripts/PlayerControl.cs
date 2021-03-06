using UnityEngine;

namespace Assets.Scripts {
    public class PlayerControl : MonoBehaviour {
        public InputLayer inputLayer;
        public float moveCircleRadius = 200f;

        private Vector2 touchBeganPoint;
        private bool allowMovement;

        public WorldCharacter self;

        public static PlayerControl Singleton { private set; get; }

        public void Awake() {
            if(Singleton != null) {
                Destroy(this);
                return;
            }
            Singleton = this;
        }

        public void Register(InputLayer inputLayer, EventLayer eventLayer) {
            self.eventLayer = eventLayer;
            this.inputLayer = inputLayer;
            inputLayer.OnTouchBegan += this.OnTouchBegan;
            inputLayer.OnTouchMoved += this.OnTouchMoved;
            inputLayer.OnTouchEnded += this.OnTouchEnded;
        }
        public void OnDestroy() {
            inputLayer.OnTouchBegan -= this.OnTouchBegan;
            inputLayer.OnTouchMoved -= this.OnTouchMoved;
            inputLayer.OnTouchEnded -= this.OnTouchEnded;
        }

        private void OnTouchEnded(Touch touch) {
            allowMovement = false;

        }

        private void OnTouchMoved(Touch touch) {
            var deltaTouch = touchBeganPoint - inputLayer.LastTouchPosition;
            if(deltaTouch.magnitude > moveCircleRadius) {
                allowMovement = true;
            }
        }
        private void OnTouchBegan(Touch touch) {
            touchBeganPoint = touch.position;
        }


        public void Update() {
            if(allowMovement && inputLayer.Touching) {
                var deltaTouch = touchBeganPoint - inputLayer.LastTouchPosition;
                // Debug.Log("touchbegan " + touchBeganPoint + " lastTouch " + inputLayer.LastTouchPosition + " magnitude " + deltaTouch.magnitude);
                var direction = new Vector3(deltaTouch.x, 0, deltaTouch.y);
                direction.Normalize();
                direction *= -1;
                self.Move(direction);

                //rotate character
            }
        }
    }
}
