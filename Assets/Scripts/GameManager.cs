using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        public GameObject playerPrefab;
        public SmoothFollow cameraSmoothFollow;
        public Transform playerSpawnPoint;

        public EventLayer eventLayer;

        public WorldCharacter playerCharacter { get; private set; }
        public bool debugGUI = true;

        public void Start() {

            SpawnPlayer();
        }
        [ContextMenu("Debug/Spawn Player")]
        public void SpawnPlayer() {
            var spawnedPlayer = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
            var control = spawnedPlayer.GetComponent<PlayerControl>();

            control.Register(this.eventLayer);

            cameraSmoothFollow.target = control.transform;

            foreach(var attacker in Attacker.list) {
                attacker.Target = control.self;
            }
        }

        [ContextMenu("Debug/ResetScene")]
        public void ResetScene(){
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}