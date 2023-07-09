using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{

    public Transform Wanderer; // preffered target
    public Transform Dog; // will attack if has to
    private Transform currentTarget;
    EnemyStats stats;
    EnemyAnimationController eac;

    public float seeDistance;
    private void Start()
    {
        stats = GetComponent<EnemyStats>();
        Wanderer = WandererBrain.Instance.transform;
        Dog = PlayerController.Instance.transform;
        eac = GetComponentInChildren<EnemyAnimationController>();
        currentTarget = Wanderer;
    }

    private void Update()
    {

        float preferredDistance = Vector3.Distance(transform.position, Wanderer.position);
        float otherDistance = Vector3.Distance(transform.position, Dog.position);

        if (otherDistance < preferredDistance)
        {
            currentTarget = Dog;
        }
        else { currentTarget = Wanderer; }

        if(WandererStats.Instance.enabled==false) currentTarget = Dog;

        if (Vector2.Distance(currentTarget.position, transform.position) < seeDistance)
        {
            MoveTowardsTarget(currentTarget);
            eac.MoveAnimation();
        }
        else
        {
            eac.IdleAnimation();
        }
      
    }

    private void MoveTowardsTarget(Transform target)
    {

        Vector3 direction = (target.position - transform.position).normalized;
      

        if (target.position.x > transform.position.x)
        {
            eac.TurnLeft();
          
        }
        else
        {
            eac.TurnRight();
        }

        transform.position += direction * stats.stats.speed * Time.deltaTime;
    }

}
