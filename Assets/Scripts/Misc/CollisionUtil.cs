using UnityEngine;
using UnityEngine.Events;

public class CollisionUtil : MonoBehaviour
{
    [SerializeField] private UnityEvent Events;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Events.Invoke();
    }
}
