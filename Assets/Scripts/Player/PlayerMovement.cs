using System;
using UnityEngine;

public class PlayerMovement : TienMonoBehaviour
{
    [SerializeField] protected Rigidbody2D playerRigidbody2D;
    [SerializeField] protected float speed = 5f;
    protected Vector2 direction = Vector2.zero;
    private PlayerActions playerInputActions;

    private float oldY;
    private float newY;

    public event Action<long> OnPlayerFalling;

    protected override void LoadComponents()
    {
        LoadPlayerRigidbody2D();
        playerInputActions = new PlayerActions();
    }

    protected virtual void LoadPlayerRigidbody2D()
    {
        if (playerRigidbody2D != null) return;
        playerRigidbody2D = GetComponentInParent<Rigidbody2D>();
        Debug.Log("LoadPlayerRigidbody2D");
    }

    private void Update()
    {
        if (playerInputActions.Move.MoveLeft.IsPressed())
        {
            direction.x = -1f;
        } else if (playerInputActions.Move.MoveRight.IsPressed())
        {
            direction.x = 1f;
        } else direction.x = 0f;

        direction.x *= speed;
        direction.y = playerRigidbody2D.velocity.y;

        CalculateChangeYAxis();

        playerRigidbody2D.velocity = direction;
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    protected virtual void CalculateChangeYAxis()
    {
        if (playerRigidbody2D.velocity.y >= 0) oldY = transform.parent.position.y;
        else
        {
            newY = transform.parent.position.y;
            float factor = 100f;
            float diff = MathF.Abs((newY - oldY) * factor);
            OnPlayerFalling?.Invoke(Convert.ToInt64(Mathf.RoundToInt(diff)));
        }
    }
}
