using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core
{
    [Serializable]
    public enum UpgradeType
    {
        Time,
        Tier
    }

    [CreateAssetMenu(fileName = "UpgradeSO", menuName = "ScriptableObjects/UpgradeSO")]
    [Serializable]
    public class UpgradeSO : ScriptableObject
    {
        public UpgradeType type;
        public Sprite icon;
        public string title;
        public string description;
        public int cost;
    }
}
