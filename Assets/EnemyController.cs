using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 20;
    public int damage = 5;
    public PlayerStat playerStat;
    int MoveSpeed = 1;
    int MaxDist = 10;
    int MinDist = 1;
    public Transform Player;
    void Start()
    {
        playerStat = GameObject.Find("Player").GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.LookAt(Player);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
               
            }
        }
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            hp = hp - playerStat.damage;
        }
    }
}