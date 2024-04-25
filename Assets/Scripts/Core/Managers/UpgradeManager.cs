using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class UpgradeManager : MonoBehaviour
    {
        public static UpgradeManager Instance;

        [SerializeField]
        private Tier currentTier = Tier.I;
        [SerializeField]
        private float currentTimer = 5f;

        private void Awake()
        {
            Instance = this;
        }

        public Tier GetCurrentTier()
        {
            return currentTier;
        }

        public float GetCurrentTimer()
        {
            return currentTimer;
        }

        public void UpgradeTier()
        {
            int tierInt = (int)currentTier;
            tierInt++;
            currentTier = (Tier)tierInt;
        }

        public void UpgradeTimer()
        {
            currentTimer -= 2;
        }

        public void BuyUpgrade(UpgradeSO upgradeSO)
        {
            switch (upgradeSO.type)
            {   
                case UpgradeType.Time:
                    UpgradeTimer();
                    break;
                case UpgradeType.Tier:
                    UpgradeTier();
                    break;
                default:
                    break;
            }
        }

    }
}
