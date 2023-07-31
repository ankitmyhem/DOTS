using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct SpawnComponent : IComponentData
{
    public Entity playerPrefab;
}
