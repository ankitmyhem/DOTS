using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[BurstCompile]
public partial struct MovingISystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
        float deltaTime = SystemAPI.Time.DeltaTime;
        JobHandle moveJob = new MoveJob
        {
            deltaTime = deltaTime,
        }.ScheduleParallel(state.Dependency);

        moveJob.Complete();

        new ReachedTargetPositionJob
        {
            randomComponent = randomComponent,
        }.Run();

    }
}

[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.Move(deltaTime);
    }
}
[BurstCompile]
public partial struct ReachedTargetPositionJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction]public RefRW<RandomComponent> randomComponent;

    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.ReachedTargetPosition(randomComponent);
    }

}