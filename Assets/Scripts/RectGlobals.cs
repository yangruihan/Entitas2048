using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu]
public class RectGlobals : ScriptableObject
{
    public GameObject RectPrefab;
}
