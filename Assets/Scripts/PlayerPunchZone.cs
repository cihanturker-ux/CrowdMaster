using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class PlayerPunchZone : MonoBehaviour {
        public WorldCharacter self;

        private List<Attacker> attackers = new List<Attacker>();

        public void DealDamage() {
            foreach(var attacker in attackers) {
                attacker.self.DealDamage(self);
            }
        }
        private void OnTriggerEnter(Collider other) {
            var attacker = other.transform.GetComponent<Attacker>();
            if(attacker != null){
                attackers.Add(attacker);
            }

        }
        private void OnTriggerExit(Collider other) {
            var attacker = other.transform.GetComponent<Attacker>();
            attackers.Remove(attacker);
        }


    }
}