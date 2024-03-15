using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _lerpRate;

    private void LateUpdate() {
        Vector3 targetPosition = _playerController.SelectedControllableCharacter.transform.position;
        targetPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _lerpRate * Time.deltaTime);
    }
}