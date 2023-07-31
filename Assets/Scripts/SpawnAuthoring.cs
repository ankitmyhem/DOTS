using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnAuthoring : MonoBehaviour
{
    public GameObject playerPrefab;
}

public class SpawnBaker : Baker<SpawnAuthoring>
{
    public override void Bake(SpawnAuthoring authoring)
    {
        AddComponent(new SpawnComponent
        {
            playerPrefab = GetEntity(authoring.playerPrefab),
        }) ;
    }
}
