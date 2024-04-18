using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class QuestBoard : MonoBehaviour
    {
        [SerializeField]
        private GameObject upgradePrefab;

        [SerializeField]
        private List<QuestSO> items = new List<QuestSO>();

        private void Start()
        {
            foreach (QuestSO questSO in items)
            {
                var instance = Instantiate(upgradePrefab);
                instance.transform.SetParent(this.transform);
                instance.GetComponent<QuestItem>().LoadQuestSOData(questSO);
                instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
