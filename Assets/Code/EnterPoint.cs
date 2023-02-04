using Code.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EnterPoint : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;

    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        // для UniLeo, который помогает управлять содержимым компонентов из редактора
        systems.ConvertScene();

        InitInjections();
        InitOneFrames();
        InitSystems();

        systems.Init();
    }

    private void Update()
    {
        // вызов всех систем, единая точка входа из одного update
        systems.Run();
    }

    private void InitInjections()
    {
    }

    private void InitSystems()
    {
        systems
            .Add(new UserInputSystem())
            .Add(new CellsHandleClickSystem());
    }

    private void InitOneFrames()
    {
    }

    private void OnDestroy()
    {
        if (systems == null) return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;
    }
}