using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // ------- Queuq ------- //
    /*public Queue<BigBoss> enemyBosses;
    bool isClicked;
    // Start is called before the first frame update
    void Start()
    {
        enemyBosses = new Queue<BigBoss>();
        enemyBosses.Enqueue(new BigBoss { Name = "Big Boss1"});
        enemyBosses.Enqueue(new BigBoss { Name = "Big Boss2"});
        enemyBosses.Enqueue(new BigBoss { Name = "Big Boss3"});
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetNextBoss();                      
        }
    }

    BigBoss GetNextBoss()
    {
        if(enemyBosses.Count > 0)
        {
            var enemy = enemyBosses.Dequeue();
            Debug.Log(enemy.Name);
            return enemy;
        }
        Debug.Log("Enemy queue is empty");
        return null;
    }*/

    // ----- Stack ----- //
    public Stack<BigBoss> bossStack;
    private void Start()
    {
        bossStack = new Stack<BigBoss>();

        bossStack.Push(new BigBoss { Name = "First Big Boss" });
        bossStack.Push(new BigBoss { Name = "Second Big Boss" });
        bossStack.Push(new BigBoss { Name = "Final Big Boss" });
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetNextBoss();
        }
    }

    BigBoss GetNextBoss()
    {
        if(bossStack.Count > 0)
        {
            var boss = bossStack.Peek();
            Debug.Log(bossStack.Count);
            return boss;
        }
        return null;
    }
}

public class BigBoss
{
    public string Name;
}