using UnityEngine;

// Might make this curved later
// https://www.google.com/search?q=curved+path+unity+2d&oq=curved+path+unity+2d&aqs=chrome..69i57j0.5591j0j7&sourceid=chrome&ie=UTF-8

// Uses TrackPlayer
public class MoveDancing : BaseEnemyMovement
{
    public float closeDis;
    public float farDis;

    SpriteRenderer sr;
    TrackTarget tp;

    int flip = 1;

    const int NEXT_TURN_TIME = 5;

    private void Awake()
    {
        base.Setup();
        sr = GetComponent<SpriteRenderer>();
        tp = GetComponent<TrackTarget>();
    }

    float nextTurn = 10000;
    private void Update()
    {
        Vector2 dir = enemy.curTarget.transform.position - transform.position;
        rb.MovePosition((Vector2)transform.position + dir.normalized * moveSpeed * flip * Time.deltaTime);
        if (dir.magnitude < closeDis)
        {
            flip = -1;
            tp.Flip(true);
            nextTurn = Time.time + NEXT_TURN_TIME;
        }
        else if (Time.time > nextTurn || dir.magnitude > farDis)
        {
            flip = 1;
            tp.Flip(false);
        }
    }
}