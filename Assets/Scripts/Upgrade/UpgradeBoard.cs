using Core;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Upgrade
{
    public class UpgradeBoard : MonoBehaviour
    {
        [SerializeField]
        private GameObject upgradePrefab;
        [SerializeField]
        private GameObject completedUpgradePrefab;

        [SerializeField]
        private List<UpgradeSO> items = new List<UpgradeSO>();

        private List<GameObject> upgrades = new List<GameObject>();

        private List<GameObject> completedUpgrades = new List<GameObject>();

        private void Start()
        {
            foreach (UpgradeSO upgradeSO in items)
            {
                InstantiateUpgrade(upgradeSO);
            }
        }

        public void InstantiateUpgrade(UpgradeSO upgradeSO)
        {
            var instance = Instantiate(upgradePrefab);
            instance.transform.SetParent(this.transform);
            instance.GetComponent<UpgradeItem>().LoadUpgradeSOData(upgradeSO);
            instance.GetComponent<UpgradeItem>().SetUpgradeBoard(this);
            instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            upgrades.Add(instance);
        }

        public void InstantiateCompletedUpgrade(UpgradeSO upgradeSO)
        {
            var instance = Instantiate(completedUpgradePrefab);
            instance.transform.SetParent(this.transform);
            instance.GetComponent<UpgradeItemCompleted>().LoadUpgradeSOData(upgradeSO);
            instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            completedUpgrades.Add(instance);
        }

        public void RemoveUpgrade(GameObject upgrade, UpgradeSO upgradeSO)
        {
            upgrades.Remove(upgrade);
            Destroy(upgrade);

            InstantiateCompletedUpgrade(upgradeSO);
        }
    }
}
