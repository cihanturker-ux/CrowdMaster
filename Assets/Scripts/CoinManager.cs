using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class CoinManager : MonoBehaviour {
        public int CoinCount = 0;
        public static CoinManager Singleton { private set; get; }

        public EventLayer eventLayer;
        public void Awake() {
            if(Singleton != null) {
                Destroy(this);
            } else {
                DontDestroyOnLoad(this);
                Singleton = this;
            }

            LoadData();
            eventLayer.OnCoinCollect.AddListener(onCoinCollect);
        }

        private void onCoinCollect() {
            this.CoinCount++;
        }

        public void OnApplicationQuit() => SaveData();

        [ContextMenu("Save Coin Data")]
        public void SaveData() {
            PlayerPrefs.SetInt("CoinManager_CoinCount", this.CoinCount);
        }

        [ContextMenu("Delete Coin Data")]
        public void DeleteData() {
            PlayerPrefs.DeleteKey("CoinManager_CoinCount");
        }

        [ContextMenu("Load Coin Data")]
        public void LoadData() {
            this.CoinCount = PlayerPrefs.GetInt("CoinManager_CoinCount");
        }
    }
}
