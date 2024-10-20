using UnityEngine;

[CreateAssetMenu(fileName = "Shake Transform Event", menuName = "Custom/Shake Transform Event 2", order = 2)]
public class CameraShaker : ScriptableObject
{
    public enum Target
    {
        Position,
        Rotation
    }

    public Target target = Target.Position;

    public float amplitude = 1.0f;
    public float frequency = 1.0f;

    public float duration = 1.0f;

    public AnimationCurve blendOverTime = new AnimationCurve(
        new Keyframe(0.0f, 0.0f, Mathf.Deg2Rad *0.0f, Mathf.Deg2Rad *720.0f),
        new Keyframe(0.2f,0.1f),
        new Keyframe(1.0f,0.0f));

    public void Init(float amplitude, float frequency, float duration, AnimationCurve blendOverTime, Target target)
    {
        this.target = target;
        this.amplitude = amplitude;
        this.frequency = frequency;
        this.duration = duration;
        this.blendOverTime = blendOverTime;
    }
}
