using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private CharacterController characterController;
    private Vector3 moveInput;
    private Vector3 velocity;

    public NavMeshAgent navAgent;
    private InputSystem_Actions inputActions;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }
     void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        characterController.Move(move * speed * Time.deltaTime);
    }

}
