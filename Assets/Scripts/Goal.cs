using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Goal : MonoBehaviour
{
    public Collider2D goal;
    [SerializeField] GameObject player;
    [SerializeField] GameObject tvStatic;
    [SerializeField] GameObject goodjob;
    public Camera camera;
    public SpriteRenderer staticRenderer;
    [SerializeField] AudioSource crank;
    [SerializeField] AudioSource goalSound;
    [SerializeField] AudioSource background;
    [SerializeField] AudioSource staticSound;
    [SerializeField] AudioSource turnSignal;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI livesText;
    public int level = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goodjob.SetActive(false);
        goal = GetComponent<CircleCollider2D>();
        camera = Camera.main;
        staticRenderer = tvStatic.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D goal) {
        level++;
        switch(level) {
            case 2:
                goalSound.Play();
                transform.position = new Vector3(6f, 12f);
                player.transform.position = new Vector3(-6f, 12f);
                StartCoroutine(moveUp());
                break;
            case 3:
                goalSound.Play();
                transform.position = new Vector3(-6f, 22f);
                player.transform.position = new Vector3(6f, 22f);
                StartCoroutine(moveUp());
                break;
            case 4:
                goalSound.Play();
                transform.position = new Vector3(6f, 32f);
                player.transform.position = new Vector3(-6f, 35f);
                StartCoroutine(moveUp());
                break;
            case 5: 
                goalSound.Play();
                transform.position = new Vector3(6f, 43f);
                player.transform.position = new Vector3(-6f, 38f);
                StartCoroutine(moveUp());
                break;
            case 6: 
                goalSound.Play();
                transform.position = new Vector3(-6f, 52f);
                player.transform.position = new Vector3(-6f, 55f);
                StartCoroutine(moveUp());
                break;
            case 7: 
                goalSound.Play();
                transform.position = new Vector3(-6f, 65f);
                player.transform.position = new Vector3(-6f, 61f);
                StartCoroutine(moveUp());
                break;
            case 8: 
                goalSound.Play();
                transform.position = new Vector3(5f, 70f);
                player.transform.position = new Vector3(-5f, 70f);
                StartCoroutine(moveUp());
                break;
            case 9: 
                goalSound.Play();
                transform.position = new Vector3(6f, 85f);
                player.transform.position = new Vector3(-6f, 78f);
                StartCoroutine(moveUp());
                break;
            case 10: 
                background.Stop();
                transform.position = new Vector3(-6f, 92f);
                player.transform.position = new Vector3(6f, 88f);
                StartCoroutine(moveUp());
                break;
            case 11:
                StartCoroutine(ending());
                break;   
        }
    }

    IEnumerator moveUp() {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(1f);
        crank.Play();
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 1f, camera.transform.position.z);
        tvStatic.transform.position = new Vector3(tvStatic.transform.position.x, tvStatic.transform.position.y + 1f);
        levelText.transform.position = new Vector3(levelText.transform.position.x, levelText.transform.position.y + 1f);
        livesText.transform.position = new Vector3(livesText.transform.position.x, livesText.transform.position.y + 1f);
        yield return new WaitForSeconds(0.1f);

        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 1f, camera.transform.position.z);
        tvStatic.transform.position = new Vector3(tvStatic.transform.position.x, tvStatic.transform.position.y + 1f);
        levelText.transform.position = new Vector3(levelText.transform.position.x, levelText.transform.position.y + 1f);
        livesText.transform.position = new Vector3(livesText.transform.position.x, livesText.transform.position.y + 1f);
        yield return new WaitForSeconds(0.1f);

        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 7f, camera.transform.position.z);
        tvStatic.transform.position = new Vector3(tvStatic.transform.position.x, tvStatic.transform.position.y + 7f);
        levelText.transform.position = new Vector3(levelText.transform.position.x, levelText.transform.position.y + 7f);
        livesText.transform.position = new Vector3(livesText.transform.position.x, livesText.transform.position.y + 7f);
        yield return new WaitForSeconds(0.1f);

        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 0.5f, camera.transform.position.z);
        tvStatic.transform.position = new Vector3(tvStatic.transform.position.x, tvStatic.transform.position.y + 0.5f);
        levelText.transform.position = new Vector3(levelText.transform.position.x, levelText.transform.position.y + 0.5f);
        livesText.transform.position = new Vector3(livesText.transform.position.x, livesText.transform.position.y + 0.5f);
        yield return new WaitForSeconds(0.1f);

        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 0.5f, camera.transform.position.z);
        tvStatic.transform.position = new Vector3(tvStatic.transform.position.x, tvStatic.transform.position.y + 0.5f);
        levelText.transform.position = new Vector3(levelText.transform.position.x, levelText.transform.position.y + 0.5f);
        livesText.transform.position = new Vector3(livesText.transform.position.x, livesText.transform.position.y + 0.5f);

        levelText.text = level.ToString();
        player.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator ending() {
        staticRenderer.color = new Color(1f,1f,1f,1f);
        staticSound.Play();
        yield return new WaitForSeconds(5f);
        staticSound.Stop();
        staticRenderer.color = new Color(0f,0f,0f,1f);
        turnSignal.Play();
        yield return new WaitForSeconds(0.3f);
        goodjob.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        goodjob.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        goodjob.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        goodjob.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        goodjob.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        goodjob.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        goodjob.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        goodjob.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Title Screen");
    }

    public int getLevel() {
        return level;
    }
}
