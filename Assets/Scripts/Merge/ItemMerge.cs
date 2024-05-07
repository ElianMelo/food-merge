using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Merge
{
    public class ItemMerge : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        private Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private MergeBoard mergeBoard;

        private ItemSlot itemSlot;
        [SerializeField]
        private ItemSO itemSO;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public Tier GetTier()
        {
            return itemSO.tier;
        }

        public void GetCanvas()
        {
            canvas = GetComponentInParent<Canvas>();
            mergeBoard = GetComponentInParent<MergeBoard>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            GetComponent<RectTransform>().anchoredPosition
                        = itemSlot.GetComponent<RectTransform>().anchoredPosition;
        }
        public void SetItemSlot(ItemSlot newItemSlot)
        {
            itemSlot = newItemSlot;
        }

        public ItemSlot GetItemSlot()
        {
            return itemSlot;
        }

        public ItemSO GetItemSO()
        {
            return itemSO;
        }

        public void OnDrop(PointerEventData eventData)
        {
            var dropObject = eventData.pointerDrag;
            if (dropObject != null)
            {
                ItemMerge previousItemMerge = dropObject.GetComponent<ItemMerge>();
                if (previousItemMerge == itemSlot)
                {
                    // Wrong Behavior
                    previousItemMerge.GetItemSlot().SetItemMerge(null);
                    return;
                }

                bool shouldSwap = mergeBoard.HandleMergeBoardOperation(previousItemMerge.GetItemSlot(), previousItemMerge,
                    itemSlot, this);

                if (shouldSwap)
                {
                    dropObject.GetComponent<RectTransform>().anchoredPosition
                        = GetComponent<RectTransform>().anchoredPosition;

                    this.GetComponent<RectTransform>().anchoredPosition
                        = itemSlot.GetComponent<RectTransform>().anchoredPosition;
                }
                else
                {
                    dropObject.GetComponent<RectTransform>().anchoredPosition
                        = previousItemMerge.GetItemSlot().GetComponent<RectTransform>().anchoredPosition;
                }

            }
        }
    }
}
