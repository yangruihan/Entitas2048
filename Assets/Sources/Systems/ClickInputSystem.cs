using UnityEngine;
using Entitas;

public class ClickInputSystem : IExecuteSystem
{
    private Contexts _contexts;

    private bool _pointerDown;
    private Vector3 _pointerDownPos;

    public ClickInputSystem(Contexts _contexts)
    {
        this._contexts = _contexts;

        _pointerDown = false;
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_pointerDown)
                return;

            _pointerDown = true;
            _pointerDownPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!_pointerDown)
                return;

            _pointerDown = false;
            var dir = Input.mousePosition - _pointerDownPos;

            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                dir.y = 0;
            else
                dir.x = 0;

            var entity = _contexts.game.CreateEntity();
            entity.isClickInput = true;
            entity.AddSlide(new Vector2(dir.x, dir.y));
        }
    }
}
