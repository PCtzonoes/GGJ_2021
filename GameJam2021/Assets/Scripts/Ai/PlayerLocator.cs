using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLocator : MonoBehaviour
{
    private EnemyAI _ai;

    [SerializeField]
    private Transform _eyePosition;
    int _layerMask = (1 << 8) | (1 << 0);

    bool _playerInRange = false;
    private void Awake()
    {
        _ai = gameObject.GetComponent<EnemyAI>();
        Debug.Log(_ai);
        if (_ai == null) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_ai.Player.gameObject == other.gameObject)
        {
            Debug.Log($"trigguered: {other.gameObject.name}");
            _playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_ai.Player.gameObject == other.gameObject)
        {
            Debug.Log($"trigguered Out: {other.gameObject.name}");
            _playerInRange = false;
        }
    }

    private void Update()
    {
        if (_playerInRange == false || _ai.CurrentState != EnemyAI.StatesAI.Patrol) return;
        RaycastHit hit;
        Vector3 target = new Vector3(_ai.Player.transform.position.x,
        _ai.Player.transform.position.y + 0.25f,
        _ai.Player.transform.position.z);
        if (Physics.Linecast(_eyePosition.position, target, out hit))
        {

            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject == _ai.Player)
            {
                _ai.PlayerFound();
            }
        }
        else Debug.Log("raycast Fail");

    }
}
