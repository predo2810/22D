using System.Collections.Generic;
using UnityEngine;

public class BGCreator : MonoBehaviour
{
    [SerializeField] private GameObject BGPrefab;

    [SerializeField] private Transform BGParent;
    [SerializeField] private Transform LastCreated;

    [SerializeField] private float ScrollSpeed;

    [SerializeField] private Vector2 MinScale;
    [SerializeField] private Vector2 MaxScale;

    private List<Transform> BGs = new List<Transform>();

    private void Start()
    {
        while (BGs.Count < 30)
            CreateBG();
    }

    private void CreateBG()
    {
        Transform bg = Instantiate(BGPrefab, BGParent).transform;
        bg.position = LastCreated.position + Vector3.right * (LastCreated.localScale.x / 2 + Random.Range(5f, 6.5f));
        bg.localScale = new Vector3(Random.Range(MinScale.x, MaxScale.x), Random.Range(MinScale.y, MaxScale.y));
        bg.position = new Vector3(bg.position.x, bg.localScale.y / 2 + Random.Range(-1f, 1f) - 8);

        BGs.Add(bg);

        LastCreated = bg;
    }

    private void Update()
    {
        if (BGs.Count < 30)
        {
            CreateBG();
        }
        else if (BGs[0].position.x < transform.position.x - 30)
        {
            Destroy(BGs[0].gameObject, 1);
            BGs.RemoveAt(0);
        }

        if (FindObjectOfType<PlayerMovement>().GameStarted)
            BGParent.position += Vector3.left * ScrollSpeed * FindObjectOfType<PlayerMovement>().MoveSpeed / 2 * Time.deltaTime;
    }
}
