using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrade
{
    public class UpgradeItemCompleted : MonoBehaviour
    {   
        [SerializeField]
        private Image icon;
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI description;

        public void LoadUpgradeSOData(UpgradeSO upgradeSO)
        {
            icon.sprite = upgradeSO.icon;
            title.text = upgradeSO.title;
            description.text = upgradeSO.description;
        }
    }
}
