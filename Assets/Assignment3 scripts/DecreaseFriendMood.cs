using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DecreaseFriendMood : ActionTask {

        public BBParameter<float> variableValue;
        public float decreaseRate;
        public float minValue;

        
		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
            variableValue.value += decreaseRate * Time.deltaTime;

            if (variableValue.value < minValue)
            {
                variableValue.value = minValue;
            }
        }

	}
}