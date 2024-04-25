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
        private List<QuestSO> items = new List<QuestSO>();

        private List<GameObject> quests = new List<GameObject>();

        private void Start()
        {
            foreach (QuestSO questSO in items)
            {
                var instance = Instantiate(questPrefab);
                instance.transform.SetParent(this.transform);
                instance.GetComponent<QuestItem>().LoadQuestSOData(questSO);
                instance.GetComponent<QuestItem>().SetQuestBoard(this);
                instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                quests.Add(instance);
            }
        }

        public void RemoveQuest(GameObject quest)
        {
            quests.Remove(quest);
            Destroy(quest);
        }
    }
}
