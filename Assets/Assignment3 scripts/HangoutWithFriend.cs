using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HangoutWithFriend : ActionTask {

        public BBParameter<Transform> friendLocation;
        public BBParameter<float> callRadius;
		public BBParameter<float> initialCallRadius;

        public float hangoutRate = 25f;
        public float endOfHangout = 100f;

        private Blackboard friendLocationBB;
        private float hangoutValue;

        protected override void OnExecute() 
		{
            friendLocationBB = friendLocation.value.GetComponent<Blackboard>();
            hangoutValue = friendLocationBB.GetVariableValue<float>("hangoutValue");

            friendLocation.value = null;
            callRadius.value = initialCallRadius.value;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
        {
            hangoutValue += hangoutRate * Time.deltaTime;

            friendLocationBB.SetVariableValue("hangoutValue", hangoutValue);

            if (hangoutValue > endOfHangout)
            {
                EndAction(true);
            }
        }
	}
}