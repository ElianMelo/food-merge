using Merge;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

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
            InvokeRepeating("CalculateItemMoneyAmount", 0, 1f);
        }

        public void CalculateItemMoneyAmount()
        {
            int sumAmount = 0;
            foreach (var item in itemSoToQty.Keys)
            {
                sumAmount += item.moneyAmount * itemSoToQty[item];
            }
            MoneyManager.Instance.AddAmount(sumAmount);
        }

        public void AddItemSO(ItemSO itemSO, int amount = 1)
        {
            if (itemSoToQty.ContainsKey(itemSO))
            {
                itemSoToQty[itemSO] += amount;
            } else
            {
                itemSoToQty[itemSO] = 1;
            }
            // Debug.Log(itemSO.tier + " - " + itemSoToQty[itemSO]);
        }

        public void RemoveItemSO(ItemSO itemSO, int amount = 1)
        {
            int qty = itemSoToQty[itemSO];
            if(qty > 0)
            {
                itemSoToQty[itemSO] -= amount;
            }
        }

        public List<ItemSO> GetItemsSO()
        {
            List<ItemSO> listItemSO = new List<ItemSO>();

            foreach (var item in itemSoToQty.Keys)
            {
                listItemSO.Add(item);
            }

            return listItemSO;
        }

        public int GetAmountByItemSO(ItemSO key)
        {
            return itemSoToQty[key];
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
