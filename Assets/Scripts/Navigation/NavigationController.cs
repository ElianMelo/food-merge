using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Navigation
{
    public class NavigationController : MonoBehaviour
    {
        [SerializeField]
        private GameObject mergeBoard;
        [SerializeField]
        private GameObject upgradeBoard;
        [SerializeField]
        private GameObject questBoard;
        [SerializeField]
        private GameObject glossaryBoard;

        public void GoToMergeBoard()
        {
            mergeBoard.SetActive(true);
            upgradeBoard.SetActive(false);
            questBoard.SetActive(false);
            glossaryBoard.SetActive(false);
        }

        public void GoToUpgradeBoard()
        {
            mergeBoard.SetActive(false);
            upgradeBoard.SetActive(true);
            questBoard.SetActive(false);
            glossaryBoard.SetActive(false);
        }

        public void GoToQuestBoard()
        {
            mergeBoard.SetActive(false);
            upgradeBoard.SetActive(false);
            questBoard.SetActive(true);
            glossaryBoard.SetActive(false);
        }

        public void GoToGlossaryBoard()
        {
            mergeBoard.SetActive(false);
            upgradeBoard.SetActive(false);
            questBoard.SetActive(false);
            glossaryBoard.SetActive(true);
        }
    }
}

