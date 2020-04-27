using UnityEngine;
using Scripts.Settings;

namespace Scripts.Camera.Movement
{
    public class CameraMovement : IMovement
    {
        private PositionHolder targerPosition;
        private PositionHolder cameraOffset;
        private Transform cameraTransform;
        private Vector3 currVelocity;
        private float dampTime = 0.3f;

        public CameraMovement(PositionHolder _targetPosition, PositionHolder _cameraOffset , Transform _cameraTransform)
        {
            targerPosition = _targetPosition;
            cameraOffset = _cameraOffset;
            cameraTransform = _cameraTransform;
        }

        public void Tick()
        {
            Move();
        }

        private void Move()
        {
            Vector3 targetPos = targerPosition.Value + cameraOffset.Value;
            targetPos.y = cameraTransform.position.y;
            cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetPos, ref currVelocity, dampTime);
        }
    }
}