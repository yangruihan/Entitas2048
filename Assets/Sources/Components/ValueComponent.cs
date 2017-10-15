using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class ValueComponent : IComponent
{
    [EntityIndex]
    public int Value;
}
