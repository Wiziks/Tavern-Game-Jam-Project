using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private ControllableCharacter[] _controllableCharacters;
    [SerializeField] private RectTransform _cursor;
    private int _selectedControllableCharacterIndex;

    private readonly Plane _raycastPlane = new Plane(Vector3.up, Vector3.zero);
    private Camera _camera;

    public ControllableCharacter SelectedControllableCharacter =>
        _controllableCharacters[_selectedControllableCharacterIndex % _controllableCharacters.Length];

    private void Start() {
        _camera = Camera.main;
        Cursor.visible = false;
        _selectedControllableCharacterIndex = 0;
    }

    private void Update() {
        SelectedControllableCharacter.MoveCharacter(-Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        SelectedControllableCharacter.RotateTo(PointInWorld);

        _cursor.position = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SelectedControllableCharacter.MoveCharacter(0f, 0f);

            _selectedControllableCharacterIndex--;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SelectedControllableCharacter.MoveCharacter(0f, 0f);

            _selectedControllableCharacterIndex++;
        }

        if (Input.GetMouseButtonDown(0))
            SelectedControllableCharacter.Interact();
    }

    private Vector3 PointInWorld {
        get {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            _raycastPlane.Raycast(ray, out float enter);
            return ray.GetPoint(enter);
        }
    }
}
