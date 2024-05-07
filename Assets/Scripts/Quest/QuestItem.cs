using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    public class QuestItem : MonoBehaviour
    {
        [SerializeField]
        private Image picture;
        [SerializeField]
        private TextMeshProUGUI description;
        [SerializeField]
        private TextMeshProUGUI reward;
        [SerializeField]
        private TextMeshProUGUI amount;
        [SerializeField]
        private Image item;
        [SerializeField]
        private QuestSO questSO;

        private ItemSO itemSO;
        private QuestBoard questBoard;

        private void Start()
        {
            LoadQuestSOData(questSO);
        }

        public void SetQuestBoard(QuestBoard questBoard)
        {
            this.questBoard = questBoard;
        }

        public void LoadQuestSOData(QuestSO questSO)
        {
            this.questSO = questSO;
            itemSO = questSO.item;
            picture.sprite = questSO.picture;
            item.sprite = itemSO.image;
            description.text = questSO.description;
            reward.text = "Reward: $" + questSO.reward;
            UpdateQuestAmount();
        }

        private void OnEnable()
        {
            UpdateQuestAmount();
        }

        public void UpdateQuestAmount()
        {
            if (!itemSO) return;
            amount.text = ItemManager.Instance.GetAmountByItemSO(itemSO) + " / " + questSO.amount;
        }

        public void CompleteQuest()
        {
            if (ItemManager.Instance.GetAmountByItemSO(itemSO) >= questSO.amount)
            {
                ItemManager.Instance.RemoveItemSO(itemSO, true, questSO.amount);
                MoneyManager.Instance.AddAmount(questSO.reward);
                questBoard.RemoveQuest(gameObject, questSO);
            }
        }
    }
}
