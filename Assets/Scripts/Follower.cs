using UnityEngine;
using NodeCanvas.Framework;

public class Follower : MonoBehaviour
{
    public Blackboard blackboard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Friendly"))
        {
            blackboard.SetVariableValue("seekTarget", other.transform);
        }
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Friendly"))
        {
            blackboard.SetVariableValue("seekTarget", null);
        }
    }
}
