using ItemData.Enums;
using UnityEngine;

namespace ItemData.Items
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_PATH, order = ORDER_IN_EDITOR)]
    public class ModuleData : ItemData<Modifications>
    {
        #region Asset menu fields
        private const string FILE_NAME = "Module Data", MENU_PATH = "Game data/Module Data";
        #endregion
    }
}