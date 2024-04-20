using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glossary
{
    public class GlossaryBoard : MonoBehaviour
    {
        [SerializeField]
        private GameObject glossaryPrefab;

        [SerializeField]
        private List<GlossarySO> items = new List<GlossarySO>();

        private void Start()
        {
            foreach (GlossarySO glossarySO in items)
            {
                var instance = Instantiate(glossaryPrefab);
                instance.transform.SetParent(this.transform);
                instance.GetComponent<GlossaryItem>().LoadGlossarySOData(glossarySO);
                instance.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}