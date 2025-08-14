using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer:MonoBehaviour
{
    [SerializeField] public Transform[] _wheelsY;

    private float _timeValue;
    private int _index1;
    private int _index2;
    private List<GhostFrame> _recordedFrames;
    private Transform[] _wheelsX;

    public void Initialize(List<GhostFrame> recordedFrames)
    {
        _recordedFrames = recordedFrames;
        _timeValue = 0;
    }

    private void Awake()
    {
        _wheelsX = new Transform[_wheelsY.Length];

        for (int i = 0; i < _wheelsY.Length; i++)
        {
            _wheelsX[i] = _wheelsY[i].GetChild(0);
        }
    }

    private void Update()
    {
        _timeValue += Time.fixedDeltaTime;
        GetIndex();
        SetTransform();
    }

    private void GetIndex()
    {
        for (int i = 0; i < _recordedFrames.Count-2; i++)
        {
            if (_recordedFrames[i].Time == _timeValue)
            {
                _index1 = i;
                _index2 = i;
                return;
            }
            else if(_recordedFrames[i].Time<_timeValue && _timeValue < _recordedFrames[i + 1].Time)
            {
                _index1 = i;
                _index2 = i + 1;
                return;
            }
        }

        _index1 = _recordedFrames.Count - 1;
        _index2 = _recordedFrames.Count - 1;
    }

    private void SetTransform()
    {
        if(_index1 == _index2)
        {
            transform.position = _recordedFrames[_index1].Position;
            transform.rotation = _recordedFrames[_index1].RotationCar;

            for (int i = 0; i < _recordedFrames[_index1].RotationWheelsY.Length; i++)
            {
                _wheelsY[i].rotation = _recordedFrames[_index1].RotationWheelsY[i]; 
            }
        }
        else
        {
            float interpolationFactor = (_timeValue - _recordedFrames[_index1].Time) /
                (_recordedFrames[_index2].Time - _recordedFrames[_index1].Time);

            transform.position = Vector3.Lerp(_recordedFrames[_index1].Position, 
                _recordedFrames[_index2].Position, interpolationFactor);

            transform.rotation = Quaternion.Slerp(_recordedFrames[_index1].RotationCar, 
                _recordedFrames[_index2].RotationCar, interpolationFactor);

            for (int i = 0; i < _recordedFrames[_index1].RotationWheelsY.Length; i++)
            {
                _wheelsY[i].rotation = Quaternion.Slerp(_recordedFrames[_index1].RotationWheelsY[i],
                    _recordedFrames[_index2].RotationWheelsY[i], interpolationFactor);

                _wheelsX[i].rotation = Quaternion.Slerp(_recordedFrames[_index1].RotationWheelsX[i],
                    _recordedFrames[_index2].RotationWheelsX[i], interpolationFactor);
            }
        }
    }
}
