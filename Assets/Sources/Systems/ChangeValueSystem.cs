using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class ChangeValueSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private HashSet<IntVector2> _changePos = new HashSet<IntVector2>();
    private GameGlobals _gameGlobals;

    public ChangeValueSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _gameGlobals = _contexts.game.gameGlobals.value;
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

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            ChangeValue(entity.slide.Dir);
            entity.isDestroyed = true;
        }
    }

    private void ChangeValue(Vector2 dir)
    {
        _changePos.Clear();
        dir.y = -dir.y;

        var normalDir = new IntVector2(dir.normalized);

        if (normalDir.X > 0)
        {
            for (int i = 0; i < _gameGlobals.BoardHeight; i++)
            {
                for (int j = _gameGlobals.BoardWidth - 2; j >= 0; j--)
                {
                    CheckNext(i, j, normalDir);
                }
            }
        }
        else if (normalDir.X < 0)
        {
            for (int i = 0; i < _gameGlobals.BoardHeight; i++)
            {
                for (int j = 1; j < _gameGlobals.BoardWidth; j++)
                {
                    CheckNext(i, j, normalDir);
                }
            }
        }
        else if (normalDir.Y > 0)
        {
            for (int j = 0; j < _gameGlobals.BoardWidth; j++)
            {
                for (int i = _gameGlobals.BoardHeight - 2; i >= 0; i--)
                {
                    CheckNext(i, j, normalDir);
                }
            }
        }
        else if (normalDir.Y < 0)
        {
            for (int j = 0; j < _gameGlobals.BoardWidth; j++)
            {
                for (int i = 1; i < _gameGlobals.BoardHeight; i++)
                {
                    CheckNext(i, j, normalDir);
                }
            }
        }
    }

    private void CheckNext(int i, int j, IntVector2 normalDir)
    {
        IntVector2 currentPos;
        GameEntity currentEntity = null;
        IntVector2 nextPos;
        GameEntity nextEntity = null;
        GameEntity emptyEntity = null;

        currentPos.X = j;
        currentPos.Y = i;
        currentEntity = _contexts.game.GetEntitiesWithPosition(currentPos).First();

        if (currentEntity == null || currentEntity.value.Value == 0)
            return;

        nextPos = currentPos;

        while (ValidPos(nextPos + normalDir))
        {
            nextPos += normalDir;

            if (_changePos.Contains(nextPos))
                break;

            nextEntity = _contexts.game.GetEntitiesWithPosition(nextPos).First();

            if (nextEntity == null)
            {
                continue;
            }

            if (nextEntity.value.Value == currentEntity.value.Value)
            {
                nextEntity.ReplaceValue(nextEntity.value.Value * 2);
                currentEntity.ReplaceValue(0);
                emptyEntity = null;
                _changePos.Add(nextPos);
                return;
            }
            else if (nextEntity.value.Value == 0)
            {
                emptyEntity = nextEntity;
            }
        }

        if (emptyEntity != null)
        {
            emptyEntity.ReplaceValue(currentEntity.value.Value);
            currentEntity.ReplaceValue(0);
        }
    }

    private bool ValidPos(IntVector2 pos)
    {
        if (pos.X >= _gameGlobals.BoardWidth || pos.X < 0
            || pos.Y >= _gameGlobals.BoardHeight || pos.Y < 0)
            return false;

        return true;
    }
}
