//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SlideComponent slide { get { return (SlideComponent)GetComponent(GameComponentsLookup.Slide); } }
    public bool hasSlide { get { return HasComponent(GameComponentsLookup.Slide); } }

    public void AddSlide(UnityEngine.Vector2 newDir) {
        var index = GameComponentsLookup.Slide;
        var component = CreateComponent<SlideComponent>(index);
        component.Dir = newDir;
        AddComponent(index, component);
    }

    public void ReplaceSlide(UnityEngine.Vector2 newDir) {
        var index = GameComponentsLookup.Slide;
        var component = CreateComponent<SlideComponent>(index);
        component.Dir = newDir;
        ReplaceComponent(index, component);
    }

    public void RemoveSlide() {
        RemoveComponent(GameComponentsLookup.Slide);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSlide;

    public static Entitas.IMatcher<GameEntity> Slide {
        get {
            if (_matcherSlide == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Slide);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSlide = matcher;
            }

            return _matcherSlide;
        }
    }
}
