using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ViewRootComponent : IComponent
{
    public RectTransform Value;
}
