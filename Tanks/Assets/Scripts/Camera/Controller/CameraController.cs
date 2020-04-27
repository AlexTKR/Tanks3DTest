using UnityEngine;
using Scripts.Camera.Movement;
using Scripts.Settings;

namespace Scripts.Camera.Controller
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] PositionHolder positionHolder;
        [SerializeField] PositionHolder cameraOffset;

        private IMovement cameraMovement;

        private void Awake()
        {
            InitializeCameraMovement();
        }

        void FixedUpdate()
        {
            cameraMovement?.Tick();
        }

        private void InitializeCameraMovement()
        {
            cameraMovement = new CameraMovement(positionHolder, cameraOffset, transform);
        }
    }
}