using ItemData.Enums;
using UnityEngine;

namespace ItemData.Items
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_PATH, order = ORDER_IN_EDITOR)]
    public class WeaponData : ItemData<Weapons>
    {
        #region Asset menu fields
        private const string FILE_NAME = "Weapon Data", MENU_PATH = "Game data/Weapon Data";
        #endregion

        #region Fields
        private const float SECONDS_IN_MINUTE = 60.0f;
        #endregion

        #region Editor fields
        [field: SerializeField, Min(0.0f)] public float Damage { get; protected set; }
        [SerializeField, Min(0.0f)] private float _shotsPerMinute = 0.0f;
        [field: SerializeField] public ElementType ElementType { get; protected set; }
        #endregion

        #region Properties
        public float ShotDelay => SECONDS_IN_MINUTE / _shotsPerMinute;
        #endregion
    }
}