using UnityEngine;

public class CoinCollector : MonoBehaviour {
    public CoinManager coinManager;
    public void Start() {
        coinManager = CoinManager.Singleton;
    }

    private void OnCollisionEnter(Collision collision) {
        var coin = collision.gameObject.GetComponent<Coin>();
        if(coin != null) {
            coinManager.CoinCount++;
            Destroy(coin);
        }
    }
}