using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class UI_LevelCounter : MonoBehaviour {
        public EventLayer eventLayer;
        public int MaxEnemyCount;
        public Slider slider;

        public void Start() {
            eventLayer.OnEnemyDeath.AddListener(onEnemyDeath);
            MaxEnemyCount = Attacker.list.Count;

        }
        private void onEnemyDeath() {
            slider.value = 1 - ((float) Attacker.list.Count) / ((float) MaxEnemyCount);
        }
    }
}