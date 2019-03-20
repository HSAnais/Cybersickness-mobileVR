using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectorySim : MonoBehaviour
{
    public LineRenderer sight; //display simulated path
    public PlayerFire plyrFire; //fire strength, location of cannon etc
    public int sgmCount = 20; //more gives a smoother line
    public float sgmScale = 1; //length of each segment

    //destination game object
    public Collider hObject;
    public Collider hitObject { get { return hObject; } }

    public Vector3 hitVect;//keep track of the position of the segment where we hit an object; continue rest from this spot

    private void FixedUpdate()
    {
        simulatePath();
    }

    public Vector3 GetHitVector() { return hitVect; }

    void simulatePath()
    {
        Vector3[] segments = new Vector3[sgmCount];
        segments[0] = plyrFire.transform.position; //ERROR - solved?

        //angle of launch
        Quaternion angle = Quaternion.AngleAxis(65, plyrFire.transform.right);
        Vector3 direction = angle * plyrFire.transform.up;

        //initial velocity
        Vector3 sgmVelocity = direction * plyrFire.fireStrength * Time.deltaTime;

        hObject = null;

        for(int i = 1; i < sgmCount; i++)
        {
            if(hObject != null)
            {
                segments[i] = hitVect;
                //Debug.Log(hitVect);
                continue;
            }
            //time it takes to traverse one segment (! careful if velocity is 0)
            float sgmTime = (sgmVelocity.sqrMagnitude != 0) ? sgmScale / sgmVelocity.magnitude : 0;
            sgmVelocity = sgmVelocity + Physics.gravity * sgmTime; //add gravity velocity for this segment's timestep

            //check for hitting an object
            RaycastHit hit;
            if (Physics.Raycast(segments[i - 1], sgmVelocity, out hit, sgmScale))
            {
                hObject = hit.collider; //this is the object hit
                segments[i] = segments[i - 1] + sgmVelocity.normalized * hit.distance; //change to next position

                //correct velocity because we didnt actually travel the whole segment
                sgmVelocity = sgmVelocity - Physics.gravity * (sgmScale - hit.distance) / sgmVelocity.magnitude;
                sgmVelocity = Vector3.Reflect(sgmVelocity, hit.normal); //simulating bounce

                hitVect = segments[i];
            }
            else
                segments[i] = segments[i - 1] + sgmVelocity * sgmTime;
        }

        Color startColor = plyrFire.nextColor;
        Color endColor = startColor;
        startColor.a = 1;
        endColor.a = 0;
        sight.SetColors(startColor, endColor);

        sight.SetVertexCount(sgmCount);
        for (int i = 0; i < sgmCount; i++)
            sight.SetPosition(i, segments[i]);
    }
}
