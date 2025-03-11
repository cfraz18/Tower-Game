using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    public Button button;
    [SerializeField] AudioSource ambience;
    [SerializeField] AudioSource click;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickButton() {
        click.Play();
        ambience.Stop();
        StartCoroutine(startGame());
    }

    IEnumerator startGame() {
        button.interactable = false;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Game");
    }
}
