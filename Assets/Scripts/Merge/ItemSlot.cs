using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Merge
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        private ItemMerge itemMerge;
        private MergeBoard mergeBoard;

        private void Awake()
        {
            mergeBoard = GetComponentInParent<MergeBoard>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            var dropObject = eventData.pointerDrag;
            if (dropObject != null)
            {
                ItemMerge previousItemMerge = dropObject.GetComponent<ItemMerge>();
                if (previousItemMerge == itemMerge)
                {
                    return;
                }

                ItemMerge currentItemMerge = itemMerge;
                GameObject oldItemSlot = previousItemMerge.GetItemSlot().gameObject;
                bool shouldSwap = mergeBoard.HandleMergeBoardOperation(previousItemMerge.GetItemSlot(), previousItemMerge,
                    this, itemMerge);

                if(shouldSwap)
                {
                    currentItemMerge.GetComponent<RectTransform>().anchoredPosition
                        = oldItemSlot.GetComponent<RectTransform>().anchoredPosition;

                    dropObject.GetComponent<RectTransform>().anchoredPosition
                        = GetComponent<RectTransform>().anchoredPosition;
                } else
                {
                    dropObject.GetComponent<RectTransform>().anchoredPosition 
                        = previousItemMerge.GetItemSlot().GetComponent<RectTransform>().anchoredPosition;
                }
                
            }
        }

        public ItemMerge GetItemMerge()
        {
            return itemMerge;
        }

        public void SetItemMerge(ItemMerge newItemMerge)
        {
            itemMerge = newItemMerge;
        }
    }
}

