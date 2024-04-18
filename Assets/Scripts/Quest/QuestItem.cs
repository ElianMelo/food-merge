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

        private void Start()
        {
            LoadQuestSOData(questSO);
        }

        public void LoadQuestSOData(QuestSO questSO)
        {
            this.questSO = questSO;
            itemSO = questSO.item;
            picture.sprite = questSO.picture;
            item.sprite = itemSO.image;
            description.text = questSO.description;
            reward.text = "Reward: $" + questSO.reward;
            amount.text = "0 / " + questSO.amount;
        }
    }
}
