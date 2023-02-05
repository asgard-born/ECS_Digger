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

    private EcsWorld world;
    private EcsSystems initialSystems;
    private EcsSystems runnableSystems;
    private SharedConfig _sharedConfig;

    private void Awake()
    {
        cellsProvider.Init();
        _sharedConfig = new SharedConfig(_mainConfigs);
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
        runnableSystems.Run();
    }

    private void InitSystems()
    {
        initialSystems
            .Add(new CellsInitSystem())
            .Init();

        runnableSystems
            .Add(new UserInputSystem())
            .Add(new CheckCellClickSystem())
            .Add(new CellsHandleClickSystem())
            .Inject(_sharedConfig)
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