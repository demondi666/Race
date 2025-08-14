using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ISceneLoadHandler<List<GhostFrame>>
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private GhostPlayer _ghostPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GhostRecorder _recorder;

    private Player _player;
    private GhostPlayer _ghost;
    private List<GhostFrame> _ghostFrames;

    public void Spawn()
    {
        SpawnPlayer();
        SpawnGhost();
    }

    private void SpawnPlayer()
    {
        _player = Instantiate(_playerPrefab, _spawnPoint);

        _recorder.Initialize(_player);
    }

    private void SpawnGhost()
    {
        if (_ghostFrames!=null)
        {
            _ghost = Instantiate(_ghostPrefab, _spawnPoint);

            _ghost.Initialize(_ghostFrames);
        }
    }

    public void OnSceneLoaded(List<GhostFrame> argument)
    {
        _ghostFrames = argument;
    }
}
