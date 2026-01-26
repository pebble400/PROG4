using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GoHome : ActionTask {

        public BBParameter<Transform> target;
        public BBParameter<float> speed;
        public BBParameter<float> arrivalDistance;

        protected override void OnUpdate() 
		{
            Vector3 moveDirection = (target.value.position - agent.transform.position).normalized;
            agent.transform.position += moveDirection * speed.value * Time.deltaTime;

            float distanceToTarget = Vector3.Distance(target.value.position, agent.transform.position);
            if (distanceToTarget < arrivalDistance.value)
            {
                EndAction(true);
            }
        }
	}
}