using UnityEngine;

namespace Scripts.Settings
{
    [CreateAssetMenu(menuName = "Holder/Possition", fileName = "Data")]
    public class PositionHolder : ScriptableObject
    {
        [SerializeField] private Vector3 value;

        public Vector3 Value
        {
            get => value;
            set => this.value = value;
        }
    }
}