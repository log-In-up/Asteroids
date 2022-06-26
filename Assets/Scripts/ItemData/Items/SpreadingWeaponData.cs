using ItemData.Enums;
using UnityEngine;

namespace ItemData.Items
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_PATH, order = ORDER_IN_EDITOR)]
    public class SpreadingWeaponData : WeaponData
    {
        #region Asset menu fields
        private const string FILE_NAME = "Spreading Weapon Data", MENU_PATH = "Game data/Spreading Weapon Data";
        #endregion

        #region Editor fields
        [field: SerializeField, Min(0.0f)] public float SpreadAngle { get; protected set; }
        #endregion
    }
}