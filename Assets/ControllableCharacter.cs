using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public abstract class ControllableCharacter : MonoBehaviour {
    [SerializeField][Min(0.1f)] private float _movementSpeed;

    [Header("Animation")]
    [SerializeField] private float _animationSpeedMultiplier;

    protected Animator animator;
    private CharacterController _characterController;

    protected bool canMove;

    private float _lastBlendValue;

    private void Start() {
        canMove = true;
        _characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public abstract void Interact();

    public virtual void MoveCharacter(float horizontal, float vertical) {
        if (canMove == false) return;

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 offset = direction * _movementSpeed;

        float blendValue = direction == Vector3.zero ? 0f : 1f;
        if (_lastBlendValue != blendValue) {
            animator.SetFloat("Blend", blendValue / 2f);
            _lastBlendValue = blendValue;
        }

        animator.SetFloat("Speed", blendValue * _movementSpeed * _animationSpeedMultiplier);

        _characterController.Move(offset * Time.deltaTime);
    }

    public virtual void RotateTo(Vector3 point) {
        if (canMove == false) return;

        point.y = transform.position.y;
        transform.LookAt(point);
    }
}
