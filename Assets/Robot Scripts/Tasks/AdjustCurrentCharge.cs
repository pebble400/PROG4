using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AdjustCurrentCharge : ActionTask {

		public float currentCharge = 0;
		public float adjustmentAmount = 0.1f;

		private Blackboard agentBlackboard;
		protected override string OnInit() {
            agentBlackboard = agent.GetComponent<Blackboard>();

            if (agentBlackboard != null) return null;
            else return $"AdjustmentCurrentCharge - {agent.name}: Unable to get Blackboard reference!";
            
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			currentCharge = agentBlackboard.GetVariableValue<float>("currentCharge");
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			currentCharge += adjustmentAmount * Time.deltaTime;

			agentBlackboard.SetVariableValue("currentCharge", currentCharge);
		}

	}
}