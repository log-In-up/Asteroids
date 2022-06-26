using ItemData.Enums;
using UnityEngine;

namespace ItemData.Items
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_PATH, order = ORDER_IN_EDITOR)]
    public class BoosterModuleData : UniqueModuleData
    {
        #region Asset menu fields
        private const string FILE_NAME = "Booster Module Data", MENU_PATH = "Game data/Boosters/Booster Module Data";
        #endregion

        #region Editor fields
        [field: SerializeField, Min(0.0f)] public float WeaponDamageModifier { get; protected set; }
        [field: SerializeField] public ElementType HardeningElement { get; protected set; }
        [field: SerializeField] public ElementType WeakeningElement { get; protected set; }
        #endregion
    }
}