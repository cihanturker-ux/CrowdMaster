using UnityEngine;

namespace Assets.Scripts {
    public class CoinCollector : MonoBehaviour {
        public EventLayer eventLayer;
        private CoinManager coinManager;
        public void Start() {
            coinManager = CoinManager.Singleton;
        }

        private void OnTriggerEnter(Collider other) {
            var coin = other.gameObject.GetComponent<Coin>();
            if(coin != null) {
                eventLayer.RaiseCoinCollectEvent();
                coinManager.CoinCount++;
                Destroy(coin.gameObject);
            }
        }
    }
}