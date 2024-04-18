using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{

    [CreateAssetMenu(fileName = "QuestSO", menuName = "ScriptableObjects/QuestSO")]
    [Serializable]
    public class QuestSO : ScriptableObject
    {
        public Sprite picture;
        public string description;
        public int reward;
        public int amount;
        public ItemSO item;
    }
}
