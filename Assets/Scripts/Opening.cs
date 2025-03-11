using UnityEngine;
using TMPro;
using System.Collections;

public class Opening : MonoBehaviour
{
    [SerializeField] AudioSource sound1;
    [SerializeField] AudioSource sound2;
    [SerializeField] AudioSource sound3;
    public TextMeshProUGUI warn;
    [SerializeField] TextMeshProUGUI instructions;
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] TextMeshProUGUI floor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        warn = GetComponent<TMPro.TextMeshProUGUI>();
        instructions.enabled = false;
        lives.enabled = false;
        floor.enabled = false;
        StartCoroutine(warning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator warning() {
        yield return new WaitForSeconds(0.5f);

        warn.text = "REACH";
        sound1.Play();
        yield return new WaitForSeconds(0.7f);
        sound1.Stop();

        warn.text = "THE";
        sound2.Play();
        yield return new WaitForSeconds(0.7f);
        sound2.Stop();

        warn.text = "TOP";
        sound3.Play();
        yield return new WaitForSeconds(0.7f);
        sound3.Stop();

        warn.text = "";
        yield return new WaitForSeconds(2f);
        instructions.enabled = true;
        lives.enabled = true;
        floor.enabled = true;
    }
}
