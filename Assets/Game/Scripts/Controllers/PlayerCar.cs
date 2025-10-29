using UnityEngine;

public class PlayerCar : MonoBehaviour, ICar, IGameStartListener, IGameEndListener
{
    public Transform Transform => transform;

    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;

    public void OnGameStart()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.linearVelocity = Vector3.zero;
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    public void OnGameEnd()
    {
        _rigidbody.isKinematic = true;
    }
}
