using UnityEngine;

namespace Assets.Scripts {
    [CreateAssetMenu(menuName = "EventLayer")]
    public class EventLayer : ScriptableObject {

        public int LowHealthTrigger = 20;

        public delegate void DamageEvent(int damage, int remaininghealth);
        public event DamageEvent OnTakeDamage;

        public delegate void LowHealthEvent();
        public event LowHealthEvent OnLowHealth;

        public delegate void DeathEvent();
        public event DeathEvent OnDeath;

        public void RaiseTakeDamage(int damage, int remaininghealth) {
            OnTakeDamage?.Invoke(damage, remaininghealth);
            if(remaininghealth < LowHealthTrigger) {
                OnLowHealth?.Invoke();
            }
        }        
        
        public void RaiseDeathEvent() {
            OnDeath?.Invoke();
        }
    }
}