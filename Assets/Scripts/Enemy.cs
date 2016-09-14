using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    
    public GameObject explosion;

    Transform targetPathNode;
    Transform selectedPath;
    int pathNodeIndex = 0;

    public float speed = 20f;
    public float health = 1;

    public int value = 1;

    // Use this for initialization
    void Start()
    {
    }

    void GetNextPathNode() {
        if (selectedPath != null) {
            if (pathNodeIndex < selectedPath.childCount) {
                targetPathNode = selectedPath.GetChild(pathNodeIndex);
                pathNodeIndex++;
            }
            else {
                targetPathNode = null;
                ReachedGoal();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
                //End of path
                ReachedGoal();
                return;

            }
        }
        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distThisFrame)
        {
            //node reached
            targetPathNode = null;
        }
        else
        {
            //move to node
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);
        }
    }
    void ReachedGoal()
    {
        GameObject.FindObjectOfType<ScoreManager>().LoseLife();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        GameObject.FindObjectOfType<ScoreManager>().money += value;
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void SetWaypoint(GameObject pathGO, int index)
    {
        selectedPath = pathGO.transform.GetChild(index);
    }

}
