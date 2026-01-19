using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {
    public class MoveTowards : ActionTask {

		public Transform target;
        public BBParameter<float> moveSpeed = 2f;
        public BBParameter<float> stoppingDistance = 0.1f;
        public BBParameter<float> turnSpeed = 180f;



        protected override string OnInit() {
			return null;
		}

		
		protected override void OnExecute() {
			//EndAction(true);
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