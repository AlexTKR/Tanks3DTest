using UnityEngine;
using Scripts.Player.InputReaders;
using Scripts.Player.Movement;
using Scripts.Player.Weapons;
using Scripts.Player.Attacking;
using Scripts.Settings; 

namespace Scripts.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private PositionHolder positionHolder;
        [SerializeField] private WeaponSystemBase weaponSystem;

        private IInputReader inputReader;
        private IMovement playerMovement;
        private IAttack playerAttack;
      
        private void Awake()
        {            
            InitiateInputReader();
            InitiatePlayerMovement();
            InitiateAttack();
        }        

        private void Update()
        {
            inputReader?.Read();
        }

        private void OnDisable()
        {
            positionHolder.Value = Vector3.zero;
        }

        private void FixedUpdate()
        {
            playerMovement?.Tick();
        }

        private void InitiateInputReader()
        {
            inputReader = new PlayerInputReader();
        }

        private void InitiatePlayerMovement()
        {
            playerMovement = new PlayerMovement(inputReader, transform, playerSettings, positionHolder);
        }

        private void InitiateAttack()
        {
            playerAttack = new PlayerAttack(inputReader, weaponSystem);
            playerAttack.InitiateAttack();
        }

    }
}