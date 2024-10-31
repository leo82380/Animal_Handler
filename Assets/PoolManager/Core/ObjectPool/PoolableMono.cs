using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public abstract class PoolableMono : MonoBehaviour
    {
        public PoolingType type;
        public abstract void ResetItem();
    }
}
