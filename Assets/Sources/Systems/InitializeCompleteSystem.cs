using Entitas;

public class InitializeCompleteSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeCompleteSystem(Contexts _contexts)
    {
        this._contexts = _contexts;
    }

    public void Initialize()
    {
        _contexts.game.ReplaceTick(0);
    }
}
