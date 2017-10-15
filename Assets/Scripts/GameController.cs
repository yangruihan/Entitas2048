using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Contexts _contexts;
    private Systems _systems;

    void Start()
    {
        _contexts = Contexts.sharedInstance;

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
            .Add(new InitializeRectSystem(_contexts))
            ;
    }
}
