using System;
using UnityEngine;

public class Zoner : MonoBehaviour
{
    public event Action<bool> EnemyEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _))
        {
            EnemyEntered?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _))
        {
            EnemyEntered?.Invoke(false);
        }
    }
}
