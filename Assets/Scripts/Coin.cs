using UnityEngine;

public class Coin : MonoBehaviour {
    public float RotationSpeed = 1;

    public void Update() {
        this.transform.rotation *= Quaternion.AngleAxis(RotationSpeed * Time.deltaTime, Vector3.up);
    }
}
