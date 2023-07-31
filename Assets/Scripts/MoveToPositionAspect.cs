using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly TransformAspect transformAspect;
    private readonly RefRO<Speed> speed;
    private readonly RefRW<TargetPosition> targetPosition;

    public void Move(float deltaTime)
    {
        float3 moveDirection = math.normalize(new float3(targetPosition.ValueRW.value - transformAspect.Position));
        transformAspect.Position += moveDirection * deltaTime * speed.ValueRO.value;
    }

    public float3 GetRandomTargetPosition(RefRW<RandomComponent> randomComponent)
    {
        return new float3(
            randomComponent.ValueRW.random.NextFloat(0f, 15f),
            0,
            randomComponent.ValueRW.random.NextFloat(0, 15f));
    }

    public void ReachedTargetPosition(RefRW<RandomComponent> randomComponent)
    {
        float reachedTargetDistance = 0.5f;
        if (math.distance(transformAspect.Position, targetPosition.ValueRW.value) < reachedTargetDistance)
        {
            targetPosition.ValueRW.value = GetRandomTargetPosition(randomComponent);
        }
    }
}
