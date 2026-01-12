using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEditor;


namespace NodeCanvas.Tasks.Actions {

	public class SetInactive : ActionTask {
		GameObject cube;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            cube = agent.gameObject;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			
			
			cube.SetActive(false);
            

			EndAction(true);
		}
	}
}