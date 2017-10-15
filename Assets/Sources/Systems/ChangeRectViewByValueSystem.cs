using System.Collections.Generic;
using Entitas;

public class ChangeRectViewByValueSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public ChangeRectViewByValueSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.Value.SetView(entity.value.Value);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasValue;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Value));
    }
}
