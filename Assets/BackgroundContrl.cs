using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundContrl : MonoBehaviour
{
    [SerializeField] List<Frezzeble> frezzebles;
    private void Start()
    {
        foreach (Transform item in transform)
        {
            frezzebles.AddRange(item.gameObject.GetComponents<Frezzeble>());
        }
        foreach (var fr in frezzebles)
        {
            fr.unFrezze();
        }
    }
}
