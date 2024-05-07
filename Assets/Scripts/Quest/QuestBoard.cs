using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class QuestBoard : MonoBehaviour
    {
        [SerializeField]
        private GameObject questPrefab;
        [SerializeField]
        private GameObject completedQuestPrefab;

        [SerializeField]
        private List<QuestSO> items = new List<QuestSO>();

        private List<GameObject> quests = new List<GameObject>();

        private List<GameObject> completedQuests = new List<GameObject>();

        private void Start()
        {
            foreach (QuestSO questSO in items)
            {
                InstantiateQuest(questSO);
            }
        }

        public void InstantiateQuest(QuestSO questSO)
        {
            var instance = Instantiate(questPrefab);
            instance.transform.SetParent(this.transform);
            instance.GetComponent<QuestItem>().LoadQuestSOData(questSO);
            instance.GetComponent<QuestItem>().SetQuestBoard(this);
            instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            quests.Add(instance);
        }

        public void InstantiateCompletedQuest(QuestSO questSO)
        {
            var instance = Instantiate(completedQuestPrefab);
            instance.transform.SetParent(this.transform);
            instance.GetComponent<QuestItemCompleted>().LoadQuestSOData(questSO);
            instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            completedQuests.Add(instance);
        }

        public void RemoveQuest(GameObject quest, QuestSO questSO)
        {
            quests.Remove(quest);
            Destroy(quest);

            InstantiateCompletedQuest(questSO);
        }
    }
}
