using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _start;
    [SerializeField] private CanvasGroup _canvasGroup;

    public UnityAction StartLevel;

    private void OnEnable()
    {
        _start.onClick.AddListener(OnStartClick);
    }

    private void OnDisable()
    {
        _start.onClick.RemoveListener(OnStartClick);
    }

    private void OnStartClick()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        StartLevel?.Invoke();
    }
}
