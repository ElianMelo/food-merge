using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable]
    public enum Tier
    {
        I,
        II,
        III,
        IV,
        V,
        VI,
        VII,
        VIII
    }

    [CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
    [Serializable]
    public class ItemSO : ScriptableObject
    {
        public Sprite image;
        public string title;
        public Tier tier;
    }
}

