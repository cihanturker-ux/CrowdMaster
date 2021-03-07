using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
    [CreateAssetMenu(menuName = "EventLayer")]
    public class EventLayer : ScriptableObject {

        public int LowHealthTrigger = 20;
         
        public UnityEvent<int,int> OnTakeDamage;
        public UnityEvent OnLowHealth;
        public UnityEvent OnDeath;

        public void RaiseTakeDamage(int damage, int remaininghealth) {
            OnTakeDamage.Invoke(damage, remaininghealth);
            if(remaininghealth < LowHealthTrigger) {
                OnLowHealth.Invoke();
            }
        }        
        
        public void RaiseDeathEvent() {
            OnDeath?.Invoke();
        }
    }
}