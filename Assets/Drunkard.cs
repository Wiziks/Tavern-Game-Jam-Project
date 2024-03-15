using UnityEngine;

public class Drunkard : ControllableCharacter {
    public override void Interact() {
        animator.SetLayerWeight(animator.GetLayerIndex("Punch"), 1f);
        Invoke(nameof(Punch), 1f);
        Invoke(nameof(EndPunch), 2f);
    }

    public void Punch() {
        print("punch");
    }

    public void EndPunch() {
        animator.SetLayerWeight(animator.GetLayerIndex("Punch"), 0f);
    }

    public void GetHit() {
        animator.SetLayerWeight(animator.GetLayerIndex("Hitted"), 1f);
        Invoke(nameof(EndGetHit), 1.13f);
    }

    public void EndGetHit() {
        animator.SetLayerWeight(animator.GetLayerIndex("Hitted"), 0f);
    }
}
