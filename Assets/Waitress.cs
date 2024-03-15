using UnityEngine;

public sealed class Waitress : ControllableCharacter {
    public override void Interact() {
        MoveCharacter(0f, 0f);
        canMove = false;

        animator.SetLayerWeight(animator.GetLayerIndex("Grab"), 1f);
        Invoke(nameof(EndInteracting), 4f);
    }

    public void EndInteracting() {
        animator.SetLayerWeight(animator.GetLayerIndex("Grab"), 0f);
        canMove = true;
    }
}
