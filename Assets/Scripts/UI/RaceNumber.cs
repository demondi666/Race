using TMPro;
using UnityEngine;

public class RaceNumber : MonoBehaviour
{
    private const string COUNTER_KEY = "SceneLoadCount";

    [SerializeField] private TMP_Text _text;

    private int _raceNumber;

    private void Start()
    {
        _raceNumber = PlayerPrefs.GetInt(COUNTER_KEY, 0) + 1;
        PlayerPrefs.SetInt(COUNTER_KEY, _raceNumber);
        PlayerPrefs.Save();
        _text.text = "Заезд: " + _raceNumber.ToString();
    }

    private void OnApplicationQuit()
    {
        ResetCounter();
    }

    private void ResetCounter()
    {
        PlayerPrefs.DeleteKey(COUNTER_KEY);
        PlayerPrefs.Save();
    }
}
