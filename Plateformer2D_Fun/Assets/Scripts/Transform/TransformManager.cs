using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformManager : MonoBehaviour
{
    [field: SerializeField] public bool _canAppear { get; set; }
    [field: SerializeField] public int _wichTransform { get; set; }

    private void Start()
    {
        _canAppear = false;
    }
}
