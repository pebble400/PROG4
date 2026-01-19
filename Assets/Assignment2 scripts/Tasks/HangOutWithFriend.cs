using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class HangOutWithFriend : ActionTask {

        public BBParameter<float> currentCharge = 0;
        public float adjustmentAmount = 0.1f;

        private Blackboard agentBlackboard;
        protected override string OnInit() {
            agentBlackboard = agent.GetComponent<Blackboard>();
            return null;
		}

		
		protected override void OnExecute() {
			//EndAction(true);
		}

		
		protected override void OnUpdate() 
		{
            currentCharge.value += adjustmentAmount * Time.deltaTime;
        }
	}
}