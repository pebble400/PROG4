using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

    public class CallFriend : ActionTask
    {

        public BBParameter<float> callRadius;
        public BBParameter<Transform> friendLocation;

        public Color callColour;
        public float callDuration;
        public int numberOfScanCirclePoints;

        private float callTimer;


        protected override void OnExecute()
        {
            callTimer = 0;
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            DrawCircle(agent.transform.position, callRadius.value, callColour, numberOfScanCirclePoints, 1f);
            callTimer += Time.deltaTime;
            if (callTimer > callDuration)
            {
                Collider[] colliders = Physics.OverlapSphere(agent.transform.position, callRadius.value);
                foreach (Collider collider in colliders)
                {
                    Blackboard blackboard = collider.GetComponent<Blackboard>();
                    float friendMood = blackboard.GetVariableValue<float>("friendMood");

                    if (friendMood == 0)
                    {
                        friendLocation.value = blackboard.GetVariableValue<Transform>("friendLocation");
                    }
                }
                EndAction(true);
            }
        }
        private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints, float duration)
        {
            Vector3 startPoint, endPoint;
            int anglePerPoint = 360 / numberOfPoints;
            for (int i = 1; i <= numberOfPoints; i++)
            {
                startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i - 1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i - 1)));
                startPoint = center + startPoint * radius;
                endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
                endPoint = center + endPoint * radius;
                Debug.DrawLine(startPoint, endPoint, colour, duration);
            }

        }
    }
}