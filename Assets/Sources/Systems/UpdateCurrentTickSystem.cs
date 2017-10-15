using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class UpdateCurrentTickSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private GameGlobals _gameGlobals;
    private IntVector2 _genPos;

    public UpdateCurrentTickSystem(Contexts _contexts) : base(_contexts.game)
    {
        this._contexts = _contexts;
        _gameGlobals = _contexts.game.gameGlobals.value;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTick;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Tick);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameEntities = _contexts.game.GetEntitiesWithValue(2048);
            if (gameEntities.Count() > 0)
            {
                _contexts.game.ReplaceGameStatus(GameStatus.Win);
            }
            else
            {
                if (GetRandomEmptyPos(out _genPos))
                {
                    var gameEntity = _contexts.game.GetEntitiesWithPosition(_genPos).First();
                    if (gameEntity != null)
                    {
                        gameEntity.ReplaceValue(_contexts.game.gameGlobals.value.RectInitValue);
                    }
                }
                else
                {
                    _contexts.game.ReplaceGameStatus(GameStatus.Over);
                }
            }
        }
    }

    private bool GetRandomEmptyPos(out IntVector2 pos)
    {
        pos = IntVector2.None;
        var entities = _contexts.game.GetEntitiesWithValue(0);
        if (entities.Count() == 0)
        {
            return false;
        }

        var index = Random.Range(0, entities.Count());
        pos = entities.Skip(index).First().position.Position;
        return true;
    }
}
