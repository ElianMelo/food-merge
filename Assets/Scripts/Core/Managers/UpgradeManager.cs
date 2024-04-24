using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class UpgradeManager : MonoBehaviour
    {
        public static UpgradeManager Instance;

        private Tier currentTier = Tier.I;
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

    }
}
