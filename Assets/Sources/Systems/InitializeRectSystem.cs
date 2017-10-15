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
        var height = _contexts.game.gameGlobals.value.BoardHeight;
        var width = _contexts.game.gameGlobals.value.BoardWidth;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                var entity = _contexts.game.CreateEntity();
                entity.AddId(i * width + j);
                entity.AddPosition(new IntVector2(j, i));
                entity.isRect = true;
                entity.AddValue(0);
            }
        }
    }
}
