using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Item[] itemPrefabs;
    [SerializeField] private Player player;
    [SerializeField] private Neighbor neighborPrefab;
    [SerializeField] private Transform minSpawnPoint;
    [SerializeField] private Transform maxSpawnPoint;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Neighbor createdNeighbor;
    private Item createdItem;
    private int score;

    private void Start()
    {
        foreach (var prefab in itemPrefabs)
        {
            prefab.gameObject.SetActive(false);
        }

        neighborPrefab.gameObject.SetActive(false);

        scoreText.text = "0";

        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Init();
        }
    }

    private void Init()
    {
        var neighbor = CreateNeighbor();
        neighbor.Init();

        player.Init();
        player.Item = CreateItem(neighbor);
    }

    private Item CreateItem(Neighbor neighbor)
    {
        if (createdItem != null)
        {
            Destroy(createdItem.gameObject);
        }

        var index = Random.Range(0, itemPrefabs.Length);
        var prefab = itemPrefabs[index];
        var item = Instantiate(prefab);
        item.gameObject.SetActive(true);
        item.OnGroundCollided += () =>
        {
            neighbor.MakeInvulnerable();
            neighbor.Movement.Stop();
        };
        createdItem = item;
        return item;
    }

    private Neighbor CreateNeighbor()
    {
        if (createdNeighbor != null)
        {
            Destroy(createdNeighbor.gameObject);
        }

        createdNeighbor = Instantiate(neighborPrefab);

        createdNeighbor.OnDeath += () =>
        {
            score++;
            scoreText.text = score.ToString();
        };

        var pos = createdNeighbor.transform.position;
        pos.x = Random.Range(
            minSpawnPoint.position.x,
            maxSpawnPoint.position.x);
        createdNeighbor.transform.position = pos;

        createdNeighbor.gameObject.SetActive(true);

        return createdNeighbor;
    }
}
