using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected bool _stunnable = false;

    [SerializeField]
    protected Vector3 _assinedPosition;

    [SerializeField]
    protected Transform[] _patrolRange;


    virtual
    protected void Awake()
    {


        if (_assinedPosition == Vector3.zero)
            _assinedPosition = transform.position;
    }
}
