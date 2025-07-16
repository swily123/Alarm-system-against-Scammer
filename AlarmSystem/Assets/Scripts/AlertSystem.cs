using UnityEngine;

public class AlertSystem : MonoBehaviour
{
    [SerializeField] Zoner _zoner;
    [SerializeField] SoundEngineer _soundEngineer;

    private void OnEnable()
    {
        _zoner.EnemyEntered += ControlSiren;
    }

    private void OnDisable()
    {
        _zoner.EnemyEntered -= ControlSiren;
    }

    private void ControlSiren(bool isEnter)
    {
        _soundEngineer.ToggleActive(isEnter);
    }
}
