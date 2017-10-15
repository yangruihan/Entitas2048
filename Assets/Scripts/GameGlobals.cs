using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu]
public class GameGlobals : ScriptableObject
{
    public int BoardWidth = 4;
    public int BoardHeight = 4;

    public int RectInitValue = 2;

    public float SlideSensitive = Screen.width / 8f;
}
