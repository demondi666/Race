using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public UnityAction Finished;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent<Player>(out Player player))
        {
            Finished?.Invoke();
        }
    }
}
