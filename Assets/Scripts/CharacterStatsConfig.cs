using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts {
    [Serializable]
    public struct CharacterStatsConfig {
        public int MaxHealth;
        public int HitDamage;
        public float MovementSpeed;
        public Material DeathMaterial;
    }
}
