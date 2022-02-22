using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueController : MonoBehaviour
{
    [SerializeField] private int value;

    public int GetValue()
    {
        return value;
    }
}
