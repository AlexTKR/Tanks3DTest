using UnityEngine;

namespace Scripts.Settings
{
    [CreateAssetMenu(menuName = "Holder/Transform", fileName = "Data")]
    public class CameraTransformHolder : ScriptableObject
    {
        private Transform cameraTransform;
        public Transform CameraTransform
        {
            get => cameraTransform; set => cameraTransform = value; 
        }
    }
}