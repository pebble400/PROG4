using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;



namespace NodeCanvas.Tasks.Actions {


	public class ChangeColour : ActionTask {

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            agent.GetComponent<Renderer>();

            return null;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            agent.GetComponent<Renderer>().material.color = randomColor;

        }
	}
}