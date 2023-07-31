using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class TargetPositionSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
        foreach (MoveToPositionAspect moveToPositionAspect
            in SystemAPI.Query<MoveToPositionAspect>())
        {
            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime);
        }
    }
}
