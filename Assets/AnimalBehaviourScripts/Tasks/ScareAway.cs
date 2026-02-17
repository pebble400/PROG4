using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ScareAway : ActionTask {

        public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<Transform> preyBBP;

        public float seekRadius = 10f;

        //Called once per frame while the action is active.
        protected override void OnUpdate() 
		{
			if (preyBBP.value == null)
			{
				EndAction();
			}
			else
			{
                float distance = Vector3.Distance(agent.transform.position, preyBBP.value.position);
                if (distance < seekRadius)
                {
                    targetPositionBBP.value -= preyBBP.value.position;
                }
            }
		}

		
	}
}