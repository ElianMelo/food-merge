using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class MoneyManager : MonoBehaviour
    {
        public static MoneyManager Instance;

        public delegate void MoneyChange();
        public static event MoneyChange OnMoneyChanged;

        private int amount = 0;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            Invoke("Test", 2f);
        }

        public void Test()
        {
            AddAmount(20);
        }

        public int GetAmount()
        {
            return amount;
        }

        public void AddAmount(int value)
        {
            amount += value;
            OnMoneyChanged?.Invoke();
        }
        public void RemoveAmount(int value)
        {
            amount -= value;
            OnMoneyChanged?.Invoke();
        }

    }
}
