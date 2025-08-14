using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    [SerializeField] private float _recordFrequancy;

    private List<GhostFrame> _recordedFrames = new List<GhostFrame>();
    private bool _isRecording;
    private float _timer;
    private float _timeValue;
    private Player _player;
    private Transform[] _playerWheelsY;
    private Transform[] _playerWheelsX;


    public void Initialize(Player player)
    {
        _player = player;

        _playerWheelsY = new Transform[_player.Wheels.Length];
        _playerWheelsX = new Transform[_player.Wheels.Length];

        for (int i = 0; i < _playerWheelsY.Length; i++)
        {
            _playerWheelsY[i] = _player.Wheels[i];
            _playerWheelsX[i] = _player.Wheels[i].GetChild(0);
        }

        StartRecording();
    }

    public List<GhostFrame> GetRecorderFrame()
    {
        return new List<GhostFrame>(_recordedFrames);
    }

    private IEnumerator Record()
    {
        while(_isRecording)
        {
            _timer += Time.fixedDeltaTime;
            _timeValue += Time.fixedDeltaTime;

            if (_isRecording && _timer >= 1 / _recordFrequancy)
            {
                Quaternion[] rotationWheelsY = new Quaternion[_playerWheelsY.Length];
                Quaternion[] rotationWheelsX = new Quaternion[_playerWheelsY.Length];

                for (int i = 0; i < _playerWheelsY.Length; i++)
                {
                    rotationWheelsY[i] = _playerWheelsY[i].rotation;
                    rotationWheelsX[i] = _playerWheelsX[i].rotation;
                }
                 
                GhostFrame frame = new GhostFrame(_player.transform.position,
                    _player.transform.rotation, _timeValue, rotationWheelsY, rotationWheelsX);

                _recordedFrames.Add(frame);
                _timer = 0;
            }

            yield return null;
        }
    }

    private void StartRecording()
    {
        _isRecording = true;
        _timeValue = 0;
        _timer = 0;
        StartCoroutine(Record());
    }
}
