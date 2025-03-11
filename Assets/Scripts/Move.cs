using UnityEngine;

public class Move : MonoBehaviour
{

    Rigidbody2D player;
    TrailRenderer trail;
    public LayerMask groundLayer;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource dash;
    public bool dashed = false;
    public bool isDashing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && isDashing == false) {
            player.linearVelocity = new Vector2(-5f, player.linearVelocity.y);
        }
        else if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && isDashing == false) {
            player.linearVelocity = new Vector2(0f, player.linearVelocity.y);
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && isDashing == false) {
            player.linearVelocity = new Vector2(5f, player.linearVelocity.y);
        }
        else if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) && isDashing == false) {
            player.linearVelocity = new Vector2(0f, player.linearVelocity.y);
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded()) {
            player.linearVelocity = new Vector2(player.linearVelocity.x, 5f);
            jump.Play();
        }
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && dashed == false) {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                dash.Play();
                isDashing = true;
                player.linearVelocity = new Vector2(-30f, player.linearVelocity.y);
                dashed = true;
                trail.emitting = true;
                Invoke("stopDashing", 0.2f);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                dash.Play();
                isDashing = true;
                player.linearVelocity = new Vector2(30f, player.linearVelocity.y);
                dashed = true;
                trail.emitting = true;
                Invoke("stopDashing", 0.2f);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
                dash.Play();
                player.linearVelocity = new Vector2(player.linearVelocity.x, 30f);
                dashed = true;
                trail.emitting = true;
                Invoke("stopDashing", 0.2f);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                dash.Play();
                player.linearVelocity = new Vector2(player.linearVelocity.x, -30f);
                dashed = true;
                trail.emitting = true;
                Invoke("stopDashing", 0.2f);
            }
        }
    }

    bool IsGrounded()
    {   
        Vector2 position = transform.position;
        position = position + Vector2.down;
        Vector2 direction = Vector2.down;
        float distance = 0.01f;
        Debug.DrawRay(position, direction, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            dashed = false;
            return true;
        }

        return false;
    }

    void stopDashing() {
        isDashing = false;
        trail.emitting = false;
        player.linearVelocity = new Vector2(0f, 0f);
    }
}
