using UnityEngine; using UnityEngine.AI;  public class MonsterMove : MonoBehaviour {     NavMeshAgent agent;     public Transform target;     public Vector3 currentPlayerPos;     public GameObject enemyDoll;     public bool isVisible = false;      private void Awake()     {         agent = GetComponent<NavMeshAgent>();     }      private void Start()     {         currentPlayerPos = target.position;         agent.SetDestination(currentPlayerPos);     }      void FixedUpdate()     {         if (currentPlayerPos != target.position)         {             if (isVisible)
            {
                agent.speed = 0;
                return;
            }             agent.speed = 1.5f;             currentPlayerPos = target.position;             agent.SetDestination(currentPlayerPos);             GetKey();         }     }      private void GetKey()
    {
        int keyCount = SpawnManager._instance.getKeyCount;
        if (keyCount == 3)
        {
            enemyDoll.SetActive(true);
            agent.speed = 2f;
        }
        else if (keyCount != 0)
        {
            agent.speed = 2f;
        }
    } } 