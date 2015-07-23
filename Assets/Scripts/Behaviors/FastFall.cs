﻿public class FastFall : AbstractBehavior
{
    public float gravityMultiplier = 5.0f;

    private float defaultGravityScale;

    void Start()
    {
        defaultGravityScale = _rb2d.gravityScale;
    }

    void Update()
    {
        var down = _inputState.GetButtonValue(inputButtons[0]);

        _rb2d.gravityScale = defaultGravityScale;
        if (down && !_collisionState.standing)
        {
            _rb2d.gravityScale *= gravityMultiplier;
        }
    }
}