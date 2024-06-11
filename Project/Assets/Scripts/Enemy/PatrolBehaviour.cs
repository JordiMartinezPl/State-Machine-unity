using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrolBehaviour : StateMachineBehaviour
{
    public GameObject[] patrolPoints;
    public int targetPoint;
    public float speed;
    private VisionGizmo visionGizmo;
    private Animator animator;

    // Se espera que este método sea un override o que se ajuste al sistema de Unity, por lo tanto, se mantiene como está.
    // Unity no llama a Start en StateMachineBehaviours. Si buscas inicialización, deberías usar OnStateEnter.
    void Start()
    {
        animator.SetBool("isRunning", true); // "IsRunning" depende de los parámetros del Animator en Unity y no se cambia aquí.
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        visionGizmo = animator.GetComponent<VisionGizmo>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.position == patrolPoints[targetPoint].transform.position)
        {
            increaseTargetInt();
        }

        Vector3 direction = patrolPoints[targetPoint].transform.position - animator.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        animator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Ajusta según la orientación de tu sprite
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, patrolPoints[targetPoint].transform.position, speed * Time.deltaTime);
        animator.SetBool("isChasing", visionGizmo.isChasing); // "IsChasing" depende de los parámetros del Animator en Unity y no se cambia aquí.
    }

    void increaseTargetInt()
    {
        targetPoint++;

        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
