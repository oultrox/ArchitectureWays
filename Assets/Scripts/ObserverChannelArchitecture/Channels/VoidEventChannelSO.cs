using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnEventRaised;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    public void RaiseEvent()
    {
        if(OnEventRaised == null)
        {
            return;
        }
        OnEventRaised.Invoke();
    }
}
