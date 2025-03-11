using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class Spikes : MonoBehaviour
{
    public Collider2D spikes;
    [SerializeField] GameObject goal;
    [SerializeField] GameObject player;
    [SerializeField] GameObject staticImage;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] AudioSource glitchSound;
    [SerializeField] AudioSource staticSound;
    [SerializeField] AudioSource background;
    public Animator anim;
    public SpriteRenderer staticRenderer;
    public int lives;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spikes = GetComponent<TilemapCollider2D>();
        anim = player.GetComponent<Animator>();
        staticRenderer = staticImage.GetComponent<SpriteRenderer>();
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D spikes) {
        StartCoroutine(respawn());
    }

    IEnumerator respawn() {
        lives--;
        livesText.text = "Lives: " + lives.ToString();
        anim.Play("Glitch");
        if(lives > 0) {
            glitchSound.Play();
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            yield return new WaitForSeconds(0.5f);
            switch(goal.GetComponent<Goal>().getLevel()) {
                case 2:
                    player.transform.position = new Vector3(-6f, 12f);
                    break;
                case 3:
                    player.transform.position = new Vector3(6f, 22f);
                    break;
                case 4:
                    player.transform.position = new Vector3(-6f, 35f);
                    break;
                case 5: 
                    player.transform.position = new Vector3(-6f, 38f);
                    break;
                case 6: 
                    player.transform.position = new Vector3(-6f, 55f);
                    break;
                case 7: 
                    player.transform.position = new Vector3(-6f, 61f);
                    break;
                case 8: 
                    player.transform.position = new Vector3(-5f, 70f);
                    break;
                case 9: 
                    player.transform.position = new Vector3(-6f, 78f);
                    break;
                case 10: 
                    player.transform.position = new Vector3(6f, 88f);
                    break;
            }
        }
        else {
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            glitchSound.Play();
            yield return new WaitForSeconds(0.2f);
            glitchSound.Play();
            yield return new WaitForSeconds(0.2f);
            glitchSound.Play();
            yield return new WaitForSeconds(0.2f);
            glitchSound.Play();
            yield return new WaitForSeconds(0.2f);

            staticRenderer.color = new Color(1f,1f,1f,1f);
            background.Stop();
            staticSound.Play();
            yield return new WaitForSeconds(3f);
            staticSound.Stop();
            staticRenderer.color = new Color(0f,0f,0f,1f);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Title Screen");
        }
        anim.Play("Default");
        player.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
    }
}
