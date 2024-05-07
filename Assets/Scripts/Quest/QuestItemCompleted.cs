using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    public class QuestItemCompleted : MonoBehaviour
    {
        [SerializeField]
        private Image picture;
        [SerializeField]
        private TextMeshProUGUI description;

        public void LoadQuestSOData(QuestSO questSO)
        {
            picture.sprite = questSO.picture;
            description.text = questSO.description;
        }
    }
}
