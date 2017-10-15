﻿using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public RectGlobals RectGlobals;
    public RectTransform ViewRoot;

    private Contexts _contexts;
    private Systems _systems;

    void Start()
    {
        _contexts = Contexts.sharedInstance;
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
            .Add(new InitializeRectSystem(_contexts))

            .Add(new AddRectViewSystem(_contexts))
            ;
    }
}
