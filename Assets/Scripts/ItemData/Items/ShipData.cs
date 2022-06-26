using ItemData.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace ItemData.Items
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_PATH, order = ORDER_IN_EDITOR)]
    public class ShipData : ItemData<Ships>
    {
        #region Asset menu fields
        private const string FILE_NAME = "Ship Data", MENU_PATH = "Game data/Ship Data";
        #endregion

        #region Editor fields
        [field: SerializeField, Min(0.0f)] public float HullStrength { get; protected set; }
        [field: SerializeField, Min(0.0f)] public float MaximumEnergyLevel { get; protected set; }
        [field: SerializeField, Min(0.0f)] public float MovementSpeed { get; protected set; }
        [field: SerializeField, Min(0.0f)] public float ShieldStrength { get; protected set; }

        [SerializeField, Min(0.0f)] private float cryogenicResistance = 0.0f;
        [SerializeField, Min(0.0f)] private float electricResistance = 0.0f;
        [SerializeField, Min(0.0f)] private float kineticResistance = 0.0f;
        [SerializeField, Min(0.0f)] private float thermalResistance = 0.0f;
        #endregion

        #region Properties
        public Dictionary<ElementType, float> GetResistance => new Dictionary<ElementType, float>
        {
            [ElementType.Cryogenic] = cryogenicResistance,
            [ElementType.Electric] = electricResistance,
            [ElementType.Kinetic] = kineticResistance,
            [ElementType.Thermal] = thermalResistance
        };
        #endregion
    }
}