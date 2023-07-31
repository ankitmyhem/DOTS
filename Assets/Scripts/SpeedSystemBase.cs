using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class SpeedSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        foreach((TransformAspect transformAspect, RefRO<Speed> speed) in SystemAPI.Query<TransformAspect, RefRO<Speed>>())
        {
            //transformAspect.Position += new float3(SystemAPI.Time.DeltaTime * speed.ValueRO.value);
        }
    }
}
