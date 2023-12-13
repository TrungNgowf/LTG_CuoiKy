using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
public class FlyingEyeMovement : StateMachineBehaviour
{
    public Transform player;
    public float speed;
    public float attackRange;
    AudioManager audioManager;
    Rigidbody2D rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.PlaySFX(audioManager.monster_scream);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            audioManager.PlaySFX(audioManager.Boss_atk);
            animator.SetTrigger("Attack");
        }

        Task.Delay(2000).ContinueWith(_ => screamFunc());
    }


    void screamFunc()
    {
        audioManager.PlaySFX(audioManager.monster_scream);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
