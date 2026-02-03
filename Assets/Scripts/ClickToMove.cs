using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
public class ClickToMove : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public LayerMask terrainLayers;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Attack.performed += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, float.MaxValue, terrainLayers))
        {
            navAgent.SetDestination(hitInfo.point);
        }
    }

    private void OnDisable()
    {
        inputActions.Player.Attack.performed -= OnAttack;
        inputActions.Disable();
    }

    //void Start()
    //{
    //    inputActions = new InputSystem_Actions();
    //    inputActions.Enable();

    //    inputActions.Player.Attack.performed += OnAttack;
    //}

    //private void OnAttack(InputAction.CallbackContext context)
    //{
    //    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
    //    {
    //        navAgent.SetDestination(hitInfo.point); 
    //    }
    //}
}
