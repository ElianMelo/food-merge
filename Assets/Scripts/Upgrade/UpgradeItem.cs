using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrade
{
    public class UpgradeItem : MonoBehaviour
    {   
        [SerializeField]
        private Image icon;
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI description;
        [SerializeField]
        private TextMeshProUGUI cost;
        [SerializeField]
        private UpgradeSO upgradeSO;

        private UpgradeBoard upgradeBoard;

        public void SetUpgradeBoard(UpgradeBoard upgradeBoard)
        {
            this.upgradeBoard = upgradeBoard;
        }

        public void LoadUpgradeSOData(UpgradeSO upgradeSO)
        {
            this.upgradeSO = upgradeSO;
            icon.sprite = upgradeSO.icon;
            title.text = upgradeSO.title;
            description.text = upgradeSO.description;
            cost.text = "$" + upgradeSO.cost;
        }

        public void BuyUpgrade()
        {
            if(MoneyManager.Instance.GetAmount() >= upgradeSO.cost)
            {
                MoneyManager.Instance.RemoveAmount(upgradeSO.cost);
                UpgradeManager.Instance.BuyUpgrade(upgradeSO);
                upgradeBoard.RemoveUpgrade(gameObject, upgradeSO);
            }
        }
    }
}
