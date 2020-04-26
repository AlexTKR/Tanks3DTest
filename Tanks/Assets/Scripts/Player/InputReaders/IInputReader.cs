using System;

namespace Scripts.Player.InputReaders
{
    public interface IInputReader
    {
        #region Movement
        float HorizontalValue { get; }
        float VerticalValue { get; }
        #endregion

        #region Attacking
        event Action onAttack;
        #endregion

        #region WeaponSystem
        event Action onNextWeapon;
        event Action onPrevWeapon;
        #endregion

        void Read();
    }
}