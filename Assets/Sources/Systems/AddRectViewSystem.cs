using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddRectViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public AddRectViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Rect, GameMatcher.Position).Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.isRect;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var rectPrefab = _contexts.game.rectGlobals.value.RectPrefab;
        foreach (var entity in entities)
        {
            var rectObj = GameObject.Instantiate(rectPrefab, entity.position.Position.ToVector3(), Quaternion.identity);
        }
    }
}
