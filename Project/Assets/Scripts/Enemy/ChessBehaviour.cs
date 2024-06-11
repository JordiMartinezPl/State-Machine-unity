using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{
    private VisionGizmo visionGizmo; // Asumiendo que VisionGizmo también sigue camelCase, esto debería estar bien.
    public float speed = 2;
    public float visionRange;

    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        visionGizmo = animator.GetComponent<VisionGizmo>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Chequea si está en rango de visión para perseguir
        animator.SetBool("isChasing", visionGizmo.isChasing); // Asumiendo isChasing en VisionGizmo
        Vector3 direction = player.position - animator.transform.position;
        direction.z = 0; // Asegúrate de que no hay cambio en el eje Z para un juego 2D

        // Movimiento hacia el jugador
        animator.transform.position += direction.normalized * speed * Time.deltaTime;

        // Rotación para mirar hacia el jugador
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        animator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Ajusta según la orientación de tu sprite
    }
}
