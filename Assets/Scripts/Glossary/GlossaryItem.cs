using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Glossary
{
    public class GlossaryItem : MonoBehaviour
    {
        [SerializeField]
        private Image icon;
        [SerializeField]
        private TextMeshProUGUI description;
        [SerializeField]
        private GlossarySO glossarySO;
        [SerializeField]
        private GlossarySO defaultGlossarySO;

        private void Start()
        {
            LoadDefaultSOData();
        }

        public void LoadGlossarySOData(GlossarySO glossarySO)
        {
            this.glossarySO = glossarySO;
        }

        public void LoadDefaultSOData()
        {
            icon.sprite = defaultGlossarySO.icon;
            description.text = defaultGlossarySO.description;
        }

        public void ChangeGlossaryShowedData()
        {
            icon.sprite = glossarySO.icon;
            description.text = glossarySO.description;
        }
    }
}
