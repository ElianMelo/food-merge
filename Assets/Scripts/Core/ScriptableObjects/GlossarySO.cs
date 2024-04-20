using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GlossarySO", menuName = "ScriptableObjects/GlossarySO")]
    [Serializable]
    public class GlossarySO : ScriptableObject
    {
        public Sprite icon;
        public string description;
    }
}

