using UnityEngine;

public class DesktopMoveInput : IMoveInput
{
    private readonly DesktopMoveInputKeyConfig keyConfig;
    public DesktopMoveInput(DesktopMoveInputKeyConfig keyConfig)
    {
        this.keyConfig = keyConfig;
    }

    public Vector3 GetDirection()
    {
        var direction = Vector3.zero;
        if (Input.GetKey(keyConfig.forwardMoveKeyCode))
            direction.z = 1f;
        else if(Input.GetKey(keyConfig.backMoveKeyCode))
            direction.z = -1f;

        if (Input.GetKey(keyConfig.leftMoveKeyCode))
            direction.x = -1f;
        else if (Input.GetKey(keyConfig.rightMoveKeyCode))
            direction.x = 1f;

        return direction;
    }
}