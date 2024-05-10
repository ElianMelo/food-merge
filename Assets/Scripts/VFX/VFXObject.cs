using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VFX
{
    public class VFXObject : MonoBehaviour
    {
        void Start()
        {
            Invoke("DestroySelf", 2f);
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }

    }
}

