using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ChangeValueSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public ChangeValueSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Debug.Log(entity.slide.Dir);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isClickInput && entity.hasSlide && entity.slide.Dir != Vector2.zero
                     && (Mathf.Abs(entity.slide.Dir.x) > _contexts.game.gameGlobals.value.SlideSensitive ||
                         Mathf.Abs(entity.slide.Dir.y) > _contexts.game.gameGlobals.value.SlideSensitive);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ClickInput);
    }
}
