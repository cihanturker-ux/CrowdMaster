using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts {
    public class WorldCharacter : MonoBehaviour {
        public CharacterStatsConfig characterStatsConfig;
        public CharacterController characterController;

        public bool useGravity = true;
        public int MaxHealth { get => characterStatsConfig.MaxHealth; }
        public int HitDamage { get => characterStatsConfig.HitDamage; }
        public float MovementSpeed { get => characterStatsConfig.MovementSpeed; }

        public EventLayer eventLayer;
        public Animator animator;

        public int CurrentHealth;
        public Vector3 Velocity { get => _velocity; }
        private Vector3 _velocity = Vector3.zero;

        private SkinnedMeshRenderer skinnedMeshRenderer;

        public void Awake() {
            this.CurrentHealth = MaxHealth;
            skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        public void DealDamage(WorldCharacter worldCharacter) {
            worldCharacter.TakeDamage(HitDamage);

            int hitindex = Mathf.RoundToInt(UnityEngine.Random.value * 2);
            animator.SetTrigger("Hit" + hitindex);
        }

        private void TakeDamage(int damage) {
            this.CurrentHealth -= damage;
            if(this.CurrentHealth <= 0) {
                eventLayer.RaiseDeathEvent();
                skinnedMeshRenderer.material = characterStatsConfig.DeadMaterial;
                skinnedMeshRenderer.sharedMaterial = characterStatsConfig.DeadMaterial;
                return;
            }

            if(eventLayer != null) {
                eventLayer.RaiseTakeDamage(damage, this.CurrentHealth);
            }
        }

        public void Move(Vector3 dir) {
            this._velocity = transform.forward * MovementSpeed * dir.magnitude;
            this.transform.rotation = Quaternion.LookRotation(dir);
        }

        public void Update() {

            _velocity *= 0.9f;//placeholder stopping
            var velDir = new Vector3(_velocity.x, 0, _velocity.z);
            animator.SetFloat("Forward", velDir.magnitude);
        }

        public void FixedUpdate() {
            //apply gravity as acceleration
            if(useGravity) {
                _velocity += Physics.gravity * Time.fixedDeltaTime;
            }

            characterController.Move(_velocity * Time.fixedDeltaTime);

        }


    }
}