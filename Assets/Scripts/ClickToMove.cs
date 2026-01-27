using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
public class ClickToMove : MonoBehaviour
{
    public NavMeshAgent navAgent;
    private InputSystem_Actions inputActions;

    void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();

        inputActions.Player.Attack.performed += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
        {
            navAgent.SetDestination(hitInfo.point); 
        }
    }
}
