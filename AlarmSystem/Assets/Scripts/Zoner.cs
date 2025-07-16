using UnityEngine;

public class Zoner : MonoBehaviour
{
    [SerializeField] private SoundEngineer _soundEngineer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _))
        {
            _soundEngineer.ToggleActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _))
        {
            _soundEngineer.ToggleActive(false);
        }
    }
}
