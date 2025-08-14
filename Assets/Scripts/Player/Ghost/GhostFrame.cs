using UnityEngine;

[System.Serializable]
public class GhostFrame
{
    public Vector3 Position { get; private set; }
    public Quaternion RotationCar { get; private set; }
    public Quaternion[] RotationWheelsY { get; private set; }
    public Quaternion[] RotationWheelsX { get; private set; }
    public float Time { get; private set; }

    public GhostFrame(Vector3 position, Quaternion rotation, float time, Quaternion[] rotationWheelsY,
        Quaternion[] rotationWheelsX)
    {
        Position = position;
        RotationCar = rotation;
        RotationWheelsY = rotationWheelsY;
        RotationWheelsX = rotationWheelsX;
        Time = time;
    }
}
