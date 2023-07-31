using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class SpawnISystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityQuery playerEntityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));

        SpawnComponent spawnComponent = SystemAPI.GetSingleton<SpawnComponent>();
        EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
        int entityCount = 2;
        if(playerEntityQuery.CalculateEntityCount() < entityCount)
        {
            entityCommandBuffer.Instantiate(spawnComponent.playerPrefab);
        }
    }
}
