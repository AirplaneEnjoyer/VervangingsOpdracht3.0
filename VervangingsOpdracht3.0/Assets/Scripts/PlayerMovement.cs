using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour

{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MovePlayer(Vector2 direction)
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * _speed * Time.deltaTime;
    }

    // Update is called once per frame
    private void start()
    {
        _playerInput.OnPlayerInputRecieved.AddListener(MovePlayer);
    }
}
