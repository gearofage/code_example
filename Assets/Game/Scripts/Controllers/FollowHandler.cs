using UnityEngine;

public class FollowHandler : IGameFixedUpdatable
{
    private readonly ICar _car;
    private readonly ICamera _camera;
    private Vector3 offset = new(0, 7, -7);

    public FollowHandler(ICar car, ICamera camera)
    {
        _car = car;
        _camera = camera;
    }

    public void OnFixedUpdate()
    {
        _camera.Transform.position = _car.Transform.position + offset;
    }
}
