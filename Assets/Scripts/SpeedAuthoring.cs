using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct Speed : IComponentData
{
    public float value;
}

public class SpeedAuthoring : MonoBehaviour
{
    public float value;
}

public class SpeedBaker : Baker<SpeedAuthoring>
{
    public override void Bake(SpeedAuthoring authoring)
    {
        AddComponent(new Speed
        {
            value = authoring.value
        });
    }
}
