using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class ViewRootComponent : IComponent
{
    public GameObject ViewRoot;
}
