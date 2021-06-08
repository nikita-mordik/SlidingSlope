using UnityEngine;

public class LaunchObjects : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] rocks;
    public GameObject[] tree_Rock;
    public GameObject flag;

    public float minTreeDelay, maxTreeDelay;
    private float nextLaunchTree;

    public float minRockDelay, maxRockDelay;
    private float nextLaunchRock;

    public float minTreeRockDelay, maxTreeRockDelay;
    private float nextLaunchTreeRock;

    public float minFlagDelay, maxFlagDelay;
    private float nextLaunchFlag;

    private Vector2 minBorder;
    private Vector2 maxBorder;

    private void Start()
    {
        minBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Update()
    {
        LaunchFlag();
        LaunchTree();
        LaunchRock();
        LaunchTreeRock();
    }

    void LaunchFlag()
    {
        if (Time.time > nextLaunchFlag)
        {
            float positionX = Random.Range(-transform.localScale.x + .5f, transform.localScale.x - .5f);
            float posX = Random.Range(-maxBorder.x + .5f, maxBorder.x -.5f);
            float posY = Random.Range(transform.position.y - 5.5f, transform.position.y + 1.5f);
            var flagPosition = new Vector3(posX, posY, transform.position.z);

            Instantiate(flag, flagPosition, Quaternion.identity);

            nextLaunchFlag = Time.time + Random.Range(minFlagDelay, maxFlagDelay);
        }
    }

    void LaunchTree()
    {
        if (Time.time > nextLaunchTree)
        {
            float positionX = Random.Range(-transform.localScale.x + .5f, transform.localScale.x - .5f);
            float posX = Random.Range(-maxBorder.x + .5f, maxBorder.x - .5f);
            float posY = Random.Range(transform.position.y - 8.5f, transform.position.y + 1f);
            var treePosition = new Vector3(posX, posY, transform.position.z);

            var randomTree = Random.Range(0, trees.Length);
            Instantiate(trees[randomTree], treePosition, Quaternion.identity);

            nextLaunchTree = Time.time + Random.Range(minTreeDelay, maxTreeDelay);
        }
    }

    void LaunchRock()
    {
        if (Time.time > nextLaunchRock)
        {
            float positionX = Random.Range(-transform.localScale.x + 2.5f, transform.localScale.x - .6f);
            float posX = Random.Range(-maxBorder.x + .5f, maxBorder.x - .5f);
            float posY = Random.Range(transform.position.y - 8f, transform.position.y + 1.5f);
            var rockPosition = new Vector3(posX, posY, transform.position.z);

            var randomRock = Random.Range(0, rocks.Length);
            Instantiate(rocks[randomRock], rockPosition, Quaternion.identity);

            nextLaunchRock = Time.time + Random.Range(minRockDelay, maxRockDelay);
        }
    }

    void LaunchTreeRock()
    {
        if (Time.time > nextLaunchTreeRock)
        {
            float positionX = Random.Range(-transform.localScale.x + 2.8f, transform.localScale.x - .3f);
            float posX = Random.Range(-maxBorder.x + .5f, maxBorder.x - .5f);
            float posY = Random.Range(transform.position.y - 8f, transform.position.y);
            var treeRockPosition = new Vector3(posX, posY, transform.position.z);

            var randomTreeRock = Random.Range(0, tree_Rock.Length);
            Instantiate(tree_Rock[randomTreeRock], treeRockPosition, Quaternion.identity);

            nextLaunchTreeRock = Time.time + Random.Range(minTreeRockDelay, maxTreeRockDelay);
        }
    }
}