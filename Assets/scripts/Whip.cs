using UnityEngine;

public class Whip : MonoBehaviour
{

    public CapsuleCollider capsule;
    public float force;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DetectCollision();
        }
    }

    void DetectCollision()
    {
        var colliders = OverlapCapsule(capsule);
        foreach (var collider in colliders)
        {
            if (collider != capsule && collider.gameObject != this.gameObject)
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    ApplyForce(rb);
                }
            }
        }
    }

    void ApplyForce(Rigidbody rb)
    {
        Vector3 playerPos = this.transform.position;
        Vector3 enemyPos = rb.transform.position;
        Vector3 forceDir = enemyPos - playerPos;
        Vector3.Normalize(forceDir);

        rb.AddForce(forceDir.x * force, forceDir.y * force, forceDir.z * force, ForceMode.Impulse);
    }

    public static Collider[] OverlapCapsule(CapsuleCollider capsule, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
    {
        Vector3 point0, point1;
        float radius;
        ToWorldSpaceCapsule(capsule, out point0, out point1, out radius);
        return Physics.OverlapCapsule(point0, point1, radius, layerMask, queryTriggerInteraction);
    }

    public static void ToWorldSpaceCapsule(CapsuleCollider capsule, out Vector3 point0, out Vector3 point1, out float radius)
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

}
