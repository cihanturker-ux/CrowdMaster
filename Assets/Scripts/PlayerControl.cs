using UnityEngine;

namespace Assets.Scripts {
    public class PlayerControl : MonoBehaviour {
        public float moveCircleRadius = 200f;
         
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

        public void Register(EventLayer eventLayer) {
            self.eventLayer = eventLayer;
        }

        private Vector2 touchBeganPoint;
        public void Update() {
            var mousepos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if(Input.GetMouseButtonDown(0)) {
                touchBeganPoint = mousepos;
            }

            if(Input.GetMouseButtonUp(0)) {
                allowMovement = false;
            }

            if(Input.GetMouseButton(0)) {
                var deltaTouch = touchBeganPoint - mousepos;
                if(deltaTouch.magnitude > moveCircleRadius) {
                    allowMovement = true;
                }
            }

            if(allowMovement) {
                var deltaTouch = touchBeganPoint - mousepos;
                // Debug.Log("touchbegan " + touchBeganPoint + " lastTouch " + inputLayer.LastTouchPosition + " magnitude " + deltaTouch.magnitude);
                var direction = new Vector3(deltaTouch.x, 0, deltaTouch.y);
                direction.Normalize();
                direction *= -1;
                self.Move(direction); 
            }
        }
    }
}
