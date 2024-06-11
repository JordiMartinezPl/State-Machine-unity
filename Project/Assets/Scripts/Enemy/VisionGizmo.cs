using System.Collections.Generic;
using UnityEngine;

public class VisionGizmo : MonoBehaviour
{
    [SerializeField]
    private float visionRange;
    [Range(0f, 360f)]
    public float visionAngle = 30f;
    public Transform head;
    public Transform player;
    public bool isChasing = false;
    public LayerMask obstacle;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        visionRange = GetComponent<Animator>().GetBehaviour<IdleBehaviour>().visionRange;
    }

    private void Update()
    {
        isChasing = false;
        Vector2 playerVector = player.position - head.position;
        if (Vector3.Angle(playerVector.normalized, head.right) < visionAngle * 0.5f)
        {
            if (playerVector.magnitude < visionRange)
            {
                if (canSee())
                {
                    isChasing = true;
                }
            }
        }
    }

   

    private void OnDrawGizmos()
    {
        float halfVisionAngle = visionAngle * .5f;
        Vector2 p1, p2;
        p1 = pointForAngle(halfVisionAngle);
        p2 = pointForAngle(-halfVisionAngle);

        Gizmos.color = isChasing ? Color.green : Color.red;
        Gizmos.DrawLine(head.position, (Vector2)head.position + p1);
        Gizmos.DrawLine(head.position, (Vector2)head.position + p2);

        Gizmos.DrawRay(head.position, head.right * 4f);
    }

    private Vector3 pointForAngle(float angle)
    {
        Vector2 ret = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * visionRange;
        return head.TransformDirection(ret);
    }
    private bool canSee()
    {
        Vector3 directionToTarget = (player.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, player.position);
        if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacle))
        {
            return true;
        }
        return false;
    }
}
