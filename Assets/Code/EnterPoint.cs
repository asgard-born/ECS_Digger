using Code.Configs;
using Code.Providers;
using Code.SharedData;
using Code.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EnterPoint : MonoBehaviour
{
    [SerializeField] private CellsProvider cellsProvider;
    [SerializeField] private MainConfigs _mainConfigs;
    [SerializeField] private Canvas _canvas;

    private EcsWorld world;
    private EcsSystems initialSystems;
    private EcsSystems runnableSystems;
    private SharedState _sharedState;

    private void Awake()
    {
        cellsProvider.Init();

        var context = new SharedState.Context
        {
            mainConfigs = _mainConfigs,
            canvas = _canvas
        };

        _sharedState = new SharedState(context);
    }

    private void Start()
    {
        world = new EcsWorld();
        initialSystems = new EcsSystems(world);
        runnableSystems = new EcsSystems(world);

        // для UniLeo, который помогает управлять содержимым компонентов из редактора
        runnableSystems.ConvertScene();

        InitSystems();
    }

    private void Update()
    {
        if (_sharedState.hasFinished) return;

        runnableSystems.Run();
    }

    private void InitSystems()
    {
        initialSystems
            .Add(new CellsInitSystem())
            .Init();

        runnableSystems
            .Add(new UserInputSystem())
            .Add(new CellHandleClickSystem())
            .Add(new DigSystem())
            .Add(new GoldHandleClickSystem())
            .Add(new GoldDragSystem())
            .Add(new LootingSystem())
            .Add(new DrawUISystem())
            .Add(new CheckGameFinishSystem())
            .Inject(_sharedState)
            .Init();
    }

    private void OnDestroy()
    {
        if (runnableSystems == null) return;

        runnableSystems.Destroy();
        runnableSystems = null;
        world.Destroy();
        world = null;
    }
}