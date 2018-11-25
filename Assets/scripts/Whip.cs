using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Whip : MonoBehaviour
{
    public float minChargeTime = 0.5f;

    public CapsuleCollider capsule;
    public float maxForce;
    public float minForce;
    public float minKnockback;
    public float maxKnockback;
    public float chargeTime;
    public float stunTime;
    private float currCountdownValue;
    private bool holdingCharge = false;
    [HideInInspector] public bool charging = false;
    public AudioSource audiosource;
    public AudioClip audioCharging;
    public AudioClip audioWhip;

    void FixedUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 5")) && !charging)
        {
            Debug.Log("whip!");

            audiosource.clip = audioCharging;
            audiosource.Play();

            if (!holdingCharge)
            {
                StartCoroutine(chargeWhip());
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp("joystick button 5"))
        {
            holdingCharge = false;
        }
    }

    private void DetectCollision(float timeCharged)
    {
        var colliders = OverlapCapsule(capsule);
        foreach (var collider in colliders)
        {
            if (collider != capsule && collider.gameObject != this.gameObject && collider.gameObject.CompareTag("Enemy"))
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    ApplyForce(rb, timeCharged);
                }
            }
        }
    }

    private void ApplyForce(Rigidbody rb, float timeCharged)
    {
        rb.gameObject.GetComponent<MoveTo>().enabled = false;
        rb.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        rb.isKinematic = false;

        Vector3 playerPos = this.transform.position;
        Vector3 enemyPos = rb.transform.position;
        Vector3 forceDir = enemyPos - playerPos;
        forceDir = Vector3.Normalize(forceDir);
        float force = MapRange(timeCharged, 0.0f, chargeTime, minForce, maxForce);
        float knock = MapRange(timeCharged, 0.0f, chargeTime, minKnockback, maxKnockback);
        rb.AddForce(forceDir.x * force, forceDir.y * knock, forceDir.z * force, ForceMode.Impulse);
        //rb.AddRelativeForce(forceDir.x * force, forceDir.y * knock, forceDir.z * force, ForceMode.Impulse);

        StartCoroutine(enemyAgentEnable(rb));
    }

    private static Collider[] OverlapCapsule(CapsuleCollider capsule, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
    {
        Vector3 point0, point1;
        float radius;
        ToWorldSpaceCapsule(capsule, out point0, out point1, out radius);
        return Physics.OverlapCapsule(point0, point1, radius, layerMask, queryTriggerInteraction);
    }

    private static void ToWorldSpaceCapsule(CapsuleCollider capsule, out Vector3 point0, out Vector3 point1, out float radius)
    {
        var center = capsule.transform.TransformPoint(capsule.center);
        radius = 0f;
        float height = 0f;
        Vector3 lossyScale = AbsVec3(capsule.transform.lossyScale);
        Vector3 dir = Vector3.zero;

        switch (capsule.direction)
        {
            case 0: // x
                radius = Mathf.Max(lossyScale.y, lossyScale.z) * capsule.radius;
                height = lossyScale.x * capsule.height;
                dir = capsule.transform.TransformDirection(Vector3.right);
                break;
            case 1: // y
                radius = Mathf.Max(lossyScale.x, lossyScale.z) * capsule.radius;
                height = lossyScale.y * capsule.height;
                dir = capsule.transform.TransformDirection(Vector3.up);
                break;
            case 2: // z
                radius = Mathf.Max(lossyScale.x, lossyScale.y) * capsule.radius;
                height = lossyScale.z * capsule.height;
                dir = capsule.transform.TransformDirection(Vector3.forward);
                break;
        }

        if (height < radius * 2f)
        {
            dir = Vector3.zero;
        }

        point0 = center + dir * (height * 0.5f - radius);
        point1 = center - dir * (height * 0.5f - radius);
    }

    private static Vector3 AbsVec3(Vector3 v)
    {
        return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
    }

    private IEnumerator chargeWhip()
    {
        float timeCharged = 0.0f;
        holdingCharge = true;
        charging = true;
        while (holdingCharge)
        {
            yield return new WaitForSeconds(0.1f);
            timeCharged += 0.1f;
        }

        if (timeCharged > chargeTime)
            timeCharged = chargeTime;
        else if (timeCharged < minChargeTime)
        {
            yield return new WaitForSeconds(minChargeTime - timeCharged);
            timeCharged = minChargeTime;
        }

        DetectCollision(timeCharged);

        audiosource.clip = audioWhip;
        audiosource.Play();

        charging = false;
    }

    private static float MapRange(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

    private IEnumerator enemyAgentEnable(Rigidbody rb)
    {
        yield return new WaitForSeconds(stunTime);
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.gameObject.GetComponent<NavMeshAgent>().enabled = true;
            rb.gameObject.GetComponent<MoveTo>().enabled = true;
        }
    }

}
