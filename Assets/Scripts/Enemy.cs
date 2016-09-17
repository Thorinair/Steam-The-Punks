using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    
    public GameObject explosion;

    Transform targetPathNode;
    Transform selectedPath;
    int pathNodeIndex = 0;

    public float speed = 20f;
    public float health = 1;

    public int value = 1;
    private bool dead = false;

    public bool isBoss = false;

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
        if (dead == false) {
            if (isBoss) {
                GameObject.FindObjectOfType<ScoreManager>().LoseLife(10);
            }
            else {
                GameObject.FindObjectOfType<ScoreManager>().LoseLife();
            }
            dead = true;
            Destroy(gameObject);
        }

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
        if (isBoss) {
            SceneManager.LoadScene("Credits");
        }
    }
    public void SetWaypoint(GameObject pathGO, int index)
    {
        selectedPath = pathGO.transform.GetChild(index);
    }

}
