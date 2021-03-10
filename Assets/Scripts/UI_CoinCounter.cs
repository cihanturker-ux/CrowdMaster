using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class UI_CoinCounter : MonoBehaviour {
        public EventLayer eventLayer;
        public Text textbar;

        public void Start() {
            eventLayer.OnCoinCollect.AddListener(OnCoinCollect);

        }
        private void OnCoinCollect() {
            textbar.text = CoinManager.Singleton.CoinCount.ToString();
        }
    }
}