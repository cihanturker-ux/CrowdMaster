using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
    [CreateAssetMenu(menuName = "EventLayer")]
    public class EventLayer : ScriptableObject {

        public int LowHealthTrigger = 20;
         
        public UnityEvent<int,int> OnTakeDamage;
        public UnityEvent OnLowHealth;
        public UnityEvent OnPlayerDeath;
        public UnityEvent OnEnemyDeath;
        public UnityEvent OnEnemy;
        public UnityEvent OnCoinCollect;

        public void RaiseTakeDamage(int damage, int remaininghealth) {
            OnTakeDamage.Invoke(damage, remaininghealth);
            if(remaininghealth < LowHealthTrigger) {
                OnLowHealth.Invoke();
            }
        }        
        
        public void RaisePlayerDeathEvent() {
            OnPlayerDeath.Invoke();
        }

        public void RaiseEnemyDeathEvent() {
            OnEnemyDeath.Invoke();
        }
        public void RaiseCoinCollectEvent() {
            OnCoinCollect.Invoke();
        }
    }
}