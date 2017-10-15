using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ChangeGameStatusSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public ChangeGameStatusSystem(Contexts _contexts) : base(_contexts.game)
    {
        this._contexts = _contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            switch (entity.gameStatus.Value)
            {
                case GameStatus.Run:
                    Debug.Log("Game Start");
                    break;

                case GameStatus.Over:
                    Debug.Log("Game Over");
                    break;
                case GameStatus.Win:
                    Debug.Log("Game Win");
                    break;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameStatus;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameStatus);
    }
}
