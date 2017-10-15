using Entitas;

public class InitializeRectSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeRectSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                var entity = _contexts.game.CreateEntity();
                entity.AddPosition(new IntVector2(i, j));
                entity.isRect = true;
            }
        }
    }
}
