using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CustomComponent : MonoBehaviour
{
    public int a = 50;
    [SerializeField] int b;
    [SerializeField] List<int> l;
}
