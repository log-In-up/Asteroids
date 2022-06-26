using System;
using UnityEngine;

namespace ItemData
{
    public abstract class ItemData<Item> : ScriptableObject where Item : Enum
    {
        #region Editor fields
        [field: SerializeField] public Item ItemID { get; protected set; }
        #endregion

        #region Asset menu fields
        private protected const int ORDER_IN_EDITOR = 1;
        #endregion
    }
}