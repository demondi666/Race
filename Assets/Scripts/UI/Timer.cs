using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timer;

    private float _currentTime;
    private bool _isRunning;

    private void Update()
    {
        if (_isRunning == false)
            return;

        _currentTime += Time.deltaTime;
        UpdateTimerDisplay();
    }

    public void StartTimer() => _isRunning = true;

    public void StopTimer() => _isRunning = false;

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(_currentTime / 60f);
        int seconds = Mathf.FloorToInt(_currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((_currentTime * 1000f) % 1000f);

        _timer.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
