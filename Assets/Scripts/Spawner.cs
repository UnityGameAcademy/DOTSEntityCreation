using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Mesh unitMesh;
    [SerializeField] private Material unitMaterial;

    private void Start()
    {
        MakeEntity();
    }

    private void MakeEntity()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype archetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(Rotation),
            typeof(RenderMesh),
            typeof(RenderBounds),
            typeof(LocalToWorld)
            );

        Entity myEntity = entityManager.CreateEntity(archetype);

        entityManager.AddComponentData(myEntity, new Translation
            {
                Value = new float3(2f, 0f, 4f)
            });

        entityManager.AddSharedComponentData(myEntity, new RenderMesh
            {
                mesh = unitMesh,
                material = unitMaterial
            });
    }
}
