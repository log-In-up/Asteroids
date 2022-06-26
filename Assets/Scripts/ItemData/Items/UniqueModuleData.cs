using UnityEngine;
using ItemData.Enums;

namespace ItemData.Items
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_PATH, order = ORDER_IN_EDITOR)]
    public class UniqueModuleData : ItemData<UniqueModifications>
    {
        #region Asset menu fields
        private const string FILE_NAME = "Unique Module Data", MENU_PATH = "Game data/Boosters/Unique Module Data";
        #endregion

        #region Editor fields
        [field: SerializeField, Range(0.0f, 1.0f)] public float HardeningValue { get; protected set; }
        [field: SerializeField, Range(0.0f, 1.0f)] public float WeakeningValue { get; protected set; }
        #endregion
    }
}