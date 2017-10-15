using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameGlobals GameGlobals;
    public RectGlobals RectGlobals;
    public RectTransform ViewRoot;

    private Contexts _contexts;
    private Systems _systems;

    void Start()
    {
        _contexts = Contexts.sharedInstance;
        _contexts.game.SetGameGlobals(GameGlobals);
        _contexts.game.SetRectGlobals(RectGlobals);
        _contexts.game.SetViewRoot(ViewRoot);

        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
    }

    Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitialGameSystem(contexts))
            .Add(new InitializeRectSystem(contexts))

            .Add(new InitializeCompleteSystem(contexts))

            .Add(new ClickInputSystem(contexts))

            .Add(new ChangeGameStatusSystem(contexts))
            .Add(new AddRectViewSystem(contexts))
            .Add(new ChangeValueSystem(contexts))
            .Add(new ChangeRectViewByValueSystem(contexts))
            .Add(new UpdateCurrentTickSystem(contexts))
            .Add(new DestroyGameEntitySystem(contexts))
            ;
    }
}
