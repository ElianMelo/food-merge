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
        private List<UpgradeSO> items = new List<UpgradeSO>();

        private void Start()
        {
            foreach (UpgradeSO upgradeSO in items)
            {
                var instance = Instantiate(upgradePrefab);
                instance.transform.SetParent(this.transform);
                instance.GetComponent<UpgradeItem>().LoadUpgradeSOData(upgradeSO);
                instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
