using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Money
{
    public class MoneyItem : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI amount;

        private void Start()
        {
            MoneyManager.OnMoneyChanged += OnMoneyChanged;
        }

        private void OnDestroy()
        {
            MoneyManager.OnMoneyChanged -= OnMoneyChanged;
        }

        public void OnMoneyChanged()
        {
            amount.text = MoneyManager.Instance.GetAmount().ToString();
        }
    }
}
