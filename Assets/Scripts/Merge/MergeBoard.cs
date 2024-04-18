using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merge
{
    public class MergeBoard : MonoBehaviour
    {
        [SerializeField]
        private List<ItemSlot> slots = new List<ItemSlot>();
        [SerializeField]
        private GameObject itemSlotPrefab;
        [SerializeField]
        private GameObject nextItemSlotPrefab;
        [SerializeField]
        private Transform itemsParent;

        private void Start()
        {
            InvokeRepeating("FillSlot", 0f, UpgradeManager.Instance.GetCurrentTimer());
        }

        public void FillSlot()
        {
            foreach(var slot in slots)
            {
                if(slot.GetItemMerge() == null)
                {
                    CreateNewItemMerge(slot, UpgradeManager.Instance.GetCurrentTier());
                    break;
                }
            }
        }

        public ItemMerge CreateNewItemMerge(ItemSlot slot, Tier tier)
        {
            GameObject instance = Instantiate(ItemManager.Instance.GetItemSlotPrefabByTier(tier));
            
            instance.transform.SetParent(itemsParent);
            instance.GetComponent<ItemMerge>().GetCanvas();
            instance.GetComponent<ItemMerge>().SetItemSlot(slot);
            instance.GetComponent<RectTransform>().anchoredPosition = slot.GetComponent<RectTransform>().anchoredPosition;
            instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            slot.SetItemMerge(instance.GetComponent<ItemMerge>());
            return instance.GetComponent<ItemMerge>();
        }

        public bool HandleMergeBoardOperation(ItemSlot previousItemSlot, ItemMerge previousItemMerge,
            ItemSlot nextItemSlot, ItemMerge nextItemMerge)
        {
            var canSwap = false;
            if(nextItemMerge == null)
            {
                HandleMove(previousItemSlot, previousItemMerge, nextItemSlot);
                return canSwap;
            }
            if(previousItemMerge.GetItemSO().tier != nextItemMerge.GetItemSO().tier)
            {
                canSwap = HandleSwap(previousItemSlot, previousItemMerge, nextItemSlot, nextItemMerge);
                return canSwap;
            }
            if(previousItemSlot && previousItemMerge.GetItemSO().tier == nextItemMerge.GetItemSO().tier)
            {
                HandleMerge(previousItemSlot, previousItemMerge, nextItemSlot, nextItemMerge);
                return canSwap;
            }

            return canSwap;
        }

        public void HandleMove(ItemSlot previousItemSlot, ItemMerge previousItemMerge,
            ItemSlot nextItemSlot)
        {
            // Debug.Log("Move: nextItemMerge is empty");
            previousItemSlot.SetItemMerge(null);
            previousItemMerge.SetItemSlot(nextItemSlot);

            nextItemSlot.SetItemMerge(previousItemMerge);
        }

        public bool HandleSwap(ItemSlot previousItemSlot, ItemMerge previousItemMerge,
            ItemSlot nextItemSlot, ItemMerge nextItemMerge)
        {
            // Debug.Log("Swap: different objects");
            previousItemSlot.SetItemMerge(nextItemMerge);
            nextItemSlot.SetItemMerge(previousItemMerge);

            previousItemMerge.SetItemSlot(nextItemSlot);
            nextItemMerge.SetItemSlot(previousItemSlot);

            return true;
        }

        public void HandleMerge(ItemSlot previousItemSlot, ItemMerge previousItemMerge,
            ItemSlot nextItemSlot, ItemMerge nextItemMerge)
        {
            // Debug.Log("Merge: same objects");
            int nextTier = (int)previousItemMerge.GetItemSO().tier;
            nextTier += 1;
            Tier tier = (Tier) nextTier;

            previousItemSlot.SetItemMerge(null);
            Destroy(previousItemMerge.gameObject);
            Destroy(nextItemMerge.gameObject);
            ItemMerge newItemMerge = CreateNewItemMerge(nextItemSlot, tier);
            nextItemSlot.SetItemMerge(newItemMerge);
        }
    }
}