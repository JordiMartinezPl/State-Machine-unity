using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    public float stayTime;
    public float visionRange;
    private VisionGizmo visionGizmo;

    private float timer;
    private Transform player;

    // onStateEnter se llama cuando una transición comienza y
    // la máquina de estados empieza a evaluar este estado
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0.0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var timeUp = isTimeUp();
        visionGizmo = animator.GetComponent<VisionGizmo>();

        animator.SetBool("isChasing", visionGizmo.isChasing);
        animator.SetBool("isPatrolling", timeUp);
    }
    private bool isTimeUp()
    {
        timer += Time.deltaTime;
        return (timer > stayTime);
    }
}
