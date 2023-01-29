using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

//Script that allows you to make Scriptable Objects that store any value beyond restarting the scene
public class FloatSmores : ScriptableObject
{
    [SerializeField] private float _value;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }
}
