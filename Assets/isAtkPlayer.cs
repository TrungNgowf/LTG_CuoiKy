using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class isAtkPlayer : StateMachineBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public float speed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float attackRange;
    AudioManager audioManager;
    Rigidbody2D rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
  

        if (player.position.x >= minX && player.position.x <= maxX && player.position.y >= minY && player.position.y <= maxY)
        {
           animator.SetBool("IsATK",true);
        }
        else
        {
            animator.SetBool("IsATK", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
 
}
