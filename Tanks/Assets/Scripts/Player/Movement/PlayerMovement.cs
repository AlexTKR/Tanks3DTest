using Scripts.Player.InputReaders;
using Scripts.Settings;
using UnityEngine;

namespace Scripts.Player.Movement
{
    public class PlayerMovement : IMovement
    {
        private IInputReader inputReader;
        private PlayerSettings playerSettings;
        private PositionHolder positionHolder;
        private Transform transform;
        private Rigidbody rb;

        public PlayerMovement(IInputReader _inputReader, Transform _transform, PlayerSettings _playerSettings, PositionHolder _positionHolder)
        {
            inputReader = _inputReader;
            playerSettings = _playerSettings;
            positionHolder = _positionHolder;
            transform = _transform;

            rb = transform.GetComponent<Rigidbody>();
        }

        public void Tick()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            Vector3 movement = transform.forward * inputReader.VerticalValue * playerSettings.MovingSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
            positionHolder.Value = rb.position;
        }

        private void Rotate()
        {
            float turnDegr = inputReader.HorizontalValue * playerSettings.TurningSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turnDegr, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}