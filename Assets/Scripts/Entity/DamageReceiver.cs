using UnityEngine;

namespace Entity
{
    [DisallowMultipleComponent]
    public sealed class DamageReceiver : MonoBehaviour
    {
        #region MonoBehaviour API
        private void OnCollisionEnter2D(Collision2D collision) { }
        #endregion

        #region Public methods
        public void OnRaycastHit() { }
        #endregion
    }
}