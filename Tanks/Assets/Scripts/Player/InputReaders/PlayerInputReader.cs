using System;
using UnityEngine;

namespace Scripts.Player.InputReaders
{
    public class PlayerInputReader : IInputReader
    {
        private float horizontalValue;
        private float verticalValue;
        private bool canAttack;

        public event Action onNextWeapon;
        public event Action onPrevWeapon;
        public event Action onAttack;

        public float HorizontalValue => horizontalValue;
        public float VerticalValue => verticalValue;
        public bool CanAttack => canAttack;

        public void Read()
        {
            horizontalValue = Input.GetAxis("Horizontal");
            verticalValue = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.W))
            {
                onNextWeapon?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                onPrevWeapon?.Invoke();
            }


            if (Input.GetKeyDown(KeyCode.X))
            {
                onAttack?.Invoke();
            }
        }
    }
}