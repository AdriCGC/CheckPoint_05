using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] PlayerControlls playerControlls;



    void Update()
    {
        animator.SetInteger("Walking", playerControlls.MoveDirection());
        animator.SetInteger("Jumping", playerControlls.JumpDirection());

    }


}
