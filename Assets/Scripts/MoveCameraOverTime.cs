using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEditor;

namespace NodeCanvas.Tasks.Conditions {

	public class MoveCameraOverTime : ConditionTask {
        public float timeCounter = 60f;
        float timer;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable()
		{
            timer = timeCounter;

        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else
            {

                timer = 0;
                return true;
            }
            return false;  
		}
	}
}