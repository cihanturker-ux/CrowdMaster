using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts {
    public class SmoothFollow : MonoBehaviour{
        public float SmoothingTime = 0.1f;
        public Transform target;

        private Vector3 velocity;
        private void Update() {
            if(!target)
                return;

            this.transform.position = Vector3.SmoothDamp(this.transform.position, this.target.position, ref velocity, SmoothingTime);
        }
    }
}
