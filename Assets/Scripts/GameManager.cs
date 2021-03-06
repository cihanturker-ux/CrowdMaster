using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        public TouchManager touchManager;
        public GameObject playerPrefab;
        public SmoothFollow cameraSmoothFollow;
        public Transform playerSpawnPoint;

        public InputLayer inputLayer;
        public EventLayer eventLayer;

        public WorldCharacter playerCharacter { get; private set; }
        public bool debugGUI = true;

        [ContextMenu("Debug/Spawn Player")]
        public void SpawnPlayer() {
            var spawnedPlayer = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
            var control = spawnedPlayer.GetComponent<PlayerControl>();

            control.Register(this.inputLayer, this.eventLayer);

            cameraSmoothFollow.target = control.transform;

            foreach(var attacker in Attacker.list) {
                attacker.Target = control.self;
            }
        }

        private void OnGUI() {
            if(!debugGUI)
                return;
            if(GUILayout.Button("Spawn Player")) {
                SpawnPlayer();
            }
        }
    }
}