using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mergeVFXPrefab;

    public static VFXManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void InstantiateMergeVFX(Vector3 position)
    {
        Instantiate(mergeVFXPrefab, position, Quaternion.identity);
    }

}
