using Merge;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Progress;

namespace Core
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager Instance;

        [SerializeField]
        private List<GameObject> itemsSlotPrefab = new List<GameObject>();

        private Dictionary<Tier, GameObject> tierToItemPrefab = new Dictionary<Tier, GameObject>();

        private Dictionary<ItemSO, int> itemSoToQty = new Dictionary<ItemSO, int>();

        private void Awake()
        {
            Instance = this;
            InitializeTierToItem();
        }

        private void Start()
        {
            
        }

        public void AddItemSO(ItemSO itemSO)
        {
            if (itemSoToQty.ContainsKey(itemSO))
            {
                itemSoToQty[itemSO] += 1;
            } else
            {
                itemSoToQty[itemSO] = 1;
            }
            // Debug.Log(itemSO.tier + " - " + itemSoToQty[itemSO]);
        }

        public void RemoveItemSO(ItemSO itemSO)
        {
            int qty = itemSoToQty[itemSO];
            if(qty > 0)
            {
                itemSoToQty[itemSO] -= 1;
            }
        }

        private void InitializeTierToItem()
        {
            foreach (var item in itemsSlotPrefab)
            {
                tierToItemPrefab.Add(item.GetComponent<ItemMerge>().GetTier(), item);
            }
        }

        public GameObject GetItemSlotPrefabByTier(Tier tier)
        {
            return tierToItemPrefab[tier];
        }

    }
}
