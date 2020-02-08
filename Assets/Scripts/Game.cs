using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Item[] itemPrefabs;
    [SerializeField] private Player player;
    [SerializeField] private Neighbor neighbor;

    private Item createdItem;

    private void Start()
    {
        foreach (var prefab in itemPrefabs)
        {
            prefab.gameObject.SetActive(false);
        }

        ResetAll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAll();
        }
    }

    private void ResetAll()
    {
        if (createdItem != null)
        {
            Destroy(createdItem.gameObject);
            createdItem = null;
        }

        player.ResetAll();
        neighbor.ResetAll();

        player.Target = CreateItem();
    }

    private Item CreateItem()
    {
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
}
