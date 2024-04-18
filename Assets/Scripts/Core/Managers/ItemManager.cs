using Merge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager Instance;

        [SerializeField]
        private List<GameObject> itemsSlotPrefab = new List<GameObject>();

        private Dictionary<Tier, GameObject> tierToItem = new Dictionary<Tier, GameObject>();

        private void Awake()
        {
            Instance = this;
            InitializeTierToItem();
        }

        private void InitializeTierToItem()
        {
            foreach (var item in itemsSlotPrefab)
            {
                tierToItem.Add(item.GetComponent<ItemMerge>().GetTier(), item);
            }
        }

        public GameObject GetItemSlotPrefabByTier(Tier tier)
        {
            return tierToItem[tier];
        }

    }
}
