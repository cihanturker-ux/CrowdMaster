using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts {

    public class Attacker : MonoBehaviour {
        public enum AttackerState {
            Searching, Attacking
        }

        public static List<Attacker> list = new List<Attacker>();
        public WorldCharacter self;

        public WorldCharacter Target;
        public AttackerState state;

        public float detectionRange = 5;
        public float attackRange = 1;

        public float AttackTimer = 1;

        public void Awake() {
            list.Add(this);
        }

        public void OnDestroy() {
            list.Remove(this);
        }


        private Coroutine CO_Attack;

        public void Update() {
            if(Target == null) {
                return;
            }
            var dist = Vector3.Distance(Target.transform.position, this.transform.position);

            switch(state) {
                case AttackerState.Attacking:
                    var dir = Target.transform.position - this.transform.position;

                    if(dist >= attackRange) {
                        self.Move(dir.normalized);
                    } 
                    
                    else if(dist < attackRange) {
                        if(CO_Attack == null && Target.CurrentHealth > 0) {
                            CO_Attack = StartCoroutine(DealDamageRoutine());
                        }else if(Target.CurrentHealth <= 0) {
                            Target = null;
                        }
                    } 
                    
                    else if(dist > detectionRange) {
                        StopCoroutine(CO_Attack);
                        state = AttackerState.Searching;
                    }

                    break;
                case AttackerState.Searching:
                    if(dist <= detectionRange) {
                        state = AttackerState.Attacking;
                    }

                    break;
            }
        }

        private IEnumerator DealDamageRoutine() {
            yield return new WaitForSeconds(AttackTimer);
            self.DealDamage(Target);
            CO_Attack = null;
        }
    }
}
