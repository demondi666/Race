using IJunior.TypedScenes;
using System.Collections;
using UnityEngine;

public class Mediator : MonoBehaviour
{
    [SerializeField] private GhostRecorder _recorder;
    [SerializeField] private Finish _finish;
    [SerializeField] private float _delayBetweenStart;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Timer _timer;
    [SerializeField] private StartButton _startButton;

    private void OnEnable()
    {
        _finish.Finished += OnFinished;
        _startButton.StartLevel += OnStarted;
    }

    private void OnDisable()
    {
        _finish.Finished -= OnFinished;
        _startButton.StartLevel -= OnStarted;
    }

    private void OnFinished()
    {
        StartCoroutine(RestartLevel());
    }

    private void OnStarted()
    {
        _timer.StartTimer();
        _spawner.Spawn();
    }

    private IEnumerator RestartLevel()
    {
        _timer.StopTimer();
        yield return new WaitForSeconds(_delayBetweenStart);

        Game.Load(_recorder.GetRecorderFrame());
    }
}
