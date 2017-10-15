using Entitas;
using UnityEngine;

public class InitialGameSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitialGameSystem(Contexts _contexts)
    {
        this._contexts = _contexts;
    }

    public void Initialize()
    {
        _contexts.game.gameGlobals.value.SlideSensitive = Screen.width / 8f;
    }
}
