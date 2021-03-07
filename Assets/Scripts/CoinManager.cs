using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
    public int CoinCount = 0;
    public static CoinManager Singleton { private set; get; }

    public void Awake() {
        if(Singleton != null) {
            Destroy(this);
        } else {
            DontDestroyOnLoad(this);
            Singleton = this;
        }

        LoadData();
    }

    public void OnApplicationQuit() => SaveData();

    public void SaveData() {
        PlayerPrefs.SetInt("CoinManager_CoinCount", this.CoinCount);
    }

    public void DeleteData() {
        PlayerPrefs.DeleteKey("CoinManager_CoinCount");
    }

    public void LoadData() {
        this.CoinCount = PlayerPrefs.GetInt("CoinManager_CoinCount");
    }

    public Coin coinPrefab;

    public void InstantiateCoin(Vector3 position, Quaternion rotation) {

    }

    //todo coin pool

}
