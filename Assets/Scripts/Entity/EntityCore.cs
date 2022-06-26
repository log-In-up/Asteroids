using UnityEngine;

namespace Entity
{
    [DisallowMultipleComponent]
    public abstract class EntityCore : MonoBehaviour
    {
        #region Virtual methods
        public virtual void ApplyDamage() { }
        #endregion
    }
}