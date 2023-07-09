using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{

    public Transform Wanderer; // preffered target
    public Transform Dog; // will attack if has to
    private Transform currentTarget;
    public EnemyStats stats;
    EnemyAnimationController eac;

    public float seedistanceMax, seedistanceMin;

    public float seeDistance;
    private void Start()
    {
        Enemies.Instance.enemiesList.Add(this);
        stats = GetComponent<EnemyStats>();
        Wanderer = WandererBrain.Instance.transform;
        Dog = PlayerController.Instance.transform;
        eac = GetComponentInChildren<EnemyAnimationController>();
        currentTarget = Wanderer;
        seeDistance = Random.Range(seedistanceMin, seedistanceMax);
        Teleport = false;
        
    }

    private void OnEnable()
    {
        Teleport = false;
        Invoke("openTeleport", 5);
    }
    public bool Teleport = false;

    void openTeleport()
    {
       
        Teleport = true;

    }
    private void Update()
    {
        if (Teleport)
            if (Vector2.Distance(transform.position, PlayerStats.Instance.transform.position) > 15)
            {
                Teleport = false;
                transform.position = PlayerStats.Instance.transform.position + new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0);
            }

        float preferredDistance = Vector3.Distance(transform.position, Wanderer.position);
        float otherDistance = Vector3.Distance(transform.position, Dog.position);

        if (otherDistance < preferredDistance)
        {
            currentTarget = Dog;
        }
        else { currentTarget = Wanderer; }

        if (WandererStats.Instance.enabled == false) currentTarget = Dog;

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
