using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveAndRotateTowards : ActionTask {

		public Transform target;
		public BBParameter<float> moveSpeed = 5f;
		public BBParameter<float> turnSpeed = 180f;
		public BBParameter<float> stoppingDistance = 0.1f;

		private Blackboard agentBlackboard;

		protected override string OnInit() 
		{
            //agentBlackboard = agent.GetComponent<Blackboard>();

            //if (agentBlackboard != null) return null;
            //else return $"MoveAndRotateTowards - {agent.name}: Unable to get Blackboard reference!";
            return null;
        }

		
		protected override void OnExecute() 
		{
			//moveSpeed = agentBlackboard.GetVariableValue<float>("moveSpeed");
			//turnSpeed = agentBlackboard.GetVariableValue<float>("turnSpeed");
			//stoppingDistance = agentBlackboard.GetVariableValue<float>("stoppingDistance");
		}

	
		protected override void OnUpdate() 
		{
			Vector3 direction = target.position - agent.transform.position;
			Quaternion rotation = Quaternion.LookRotation(direction);

			agent.transform.SetPositionAndRotation(
				agent.transform.position + moveSpeed.value * Time.deltaTime * agent.transform.forward,
				Quaternion.RotateTowards(agent.transform.rotation, rotation, turnSpeed.value * Time.deltaTime)
				);

			if (Vector3.Distance(agent.transform.position, target.position) < stoppingDistance.value)
			{
				EndAction(true);
			}
		}
	}
}