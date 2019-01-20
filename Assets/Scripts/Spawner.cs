using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Text scoreText;

    public GameObject[] figures;
    private GameObject nextFigure;

    public Image image;

    void Start ()
    {
        ChooseFigure();
        Spawn();
	}

    private void Update()
    {
        scoreText.text = Field.score.ToString();
    }

    #region Choose which figure is next

    private void ChooseFigure()
    {
        int rnd = Random.Range(0, 101);

        if (rnd >= 0 && rnd <= 10)
        {
            nextFigure = figures[0];
            image.sprite = figures[0].GetComponent<Figure>().sprite;
        }
        else if (rnd >= 10 && rnd <= 20)
        {
            nextFigure = figures[1];
            image.sprite = figures[1].GetComponent<Figure>().sprite;
        }
        else if (rnd >= 20 && rnd <= 35)
        {
            nextFigure = figures[2];
            image.sprite = figures[2].GetComponent<Figure>().sprite;
        }
        else if (rnd >= 35 && rnd <= 50)
        {
            nextFigure = figures[3];
            image.sprite = figures[3].GetComponent<Figure>().sprite;
        }
        else if (rnd >= 50 && rnd <= 65)
        {
            nextFigure = figures[4];
            image.sprite = figures[4].GetComponent<Figure>().sprite;
        }
        else if (rnd >= 65 && rnd <= 80)
        {
            nextFigure = figures[5];
            image.sprite = figures[5].GetComponent<Figure>().sprite;
        }
        else if (rnd >= 80 && rnd <= 100)
        {
            nextFigure = figures[6];
            image.sprite = figures[6].GetComponent<Figure>().sprite;
        }
    }

    #endregion

    public void Spawn() // Spawn figure and choose next
    {
        SpawnFigure(nextFigure);
        ChooseFigure();
    }

    void SpawnFigure(GameObject gameObject) 
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
