using UnityEngine;
using Zenject;

public class MoveHandler : IGameFixedUpdatable
{
    private readonly ICar _car;
    private readonly IMoveInput _moveInput;

    public MoveHandler(ICar car, IMoveInput moveInput)
    {
        _car = car;
        _moveInput = moveInput;
    }

    public void OnFixedUpdate()
    {
        if (_car.Rigidbody.isKinematic) return;
        
        _car.Rigidbody.AddForce(_moveInput.GetDirection().z * 15f * _car.Transform.forward);
        _car.Rigidbody.angularVelocity = new Vector3(0, 180f * Mathf.Deg2Rad * _moveInput.GetDirection().x , 0);
    }
}