﻿using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Player.HealthSystem
{
    public abstract class HealthSystemBase : MonoBehaviour
    {
        [SerializeField] protected Slider healthSlider;
        [SerializeField] protected UnityEngine.Camera mainCamera;

        public abstract void Initiate();
        public abstract void Tick();
    }
}