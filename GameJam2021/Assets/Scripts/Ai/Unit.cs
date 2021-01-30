using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected bool _stunnable = false;

    [SerializeField]
    protected Vector3 _assinedPosition;

    [SerializeField]
    protected Transform[] _patrolRange;

    protected NavMeshAgent _navAgent;

    protected Coroutine _currentState;

    virtual
    protected void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();

        if (_assinedPosition == Vector3.zero)
            _assinedPosition = transform.position;
    }
}
