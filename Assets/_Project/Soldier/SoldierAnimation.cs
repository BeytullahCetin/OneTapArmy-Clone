using UnityEngine;

public class SoldierAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    const string runAnimationKey = "Run";
    const string attackAnimationKey = "Attack";
    const string deathAnimationKey = "Death";

    public void StartRunAnimation()
    {
        animator.SetBool(runAnimationKey, true);
    }

    public void StopRunAnimation()
    {
        animator.SetBool(runAnimationKey, false);
    }

    public void StartAttackAnimation()
    {
        animator.SetBool(attackAnimationKey, true);
    }

    public void StopAttackAnimation()
    {
        animator.SetBool(attackAnimationKey, false);
    }

    public void TriggerDeathAninmation()
    {
        animator.SetTrigger(deathAnimationKey);
    }
}
