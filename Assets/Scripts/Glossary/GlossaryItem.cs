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

        public void LoadGlossarySOData(GlossarySO glossarySO)
        {
            this.glossarySO = glossarySO;
            icon.sprite = glossarySO.icon;
            description.text = glossarySO.description;
        }
    }
}
