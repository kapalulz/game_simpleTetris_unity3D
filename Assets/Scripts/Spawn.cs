using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Tetrominoes[] tetrominoes;
    [SerializeField] private Image nextField;
    [SerializeField] public Sprite spriteBlack;
    private Tetrominoes _nextTetrominoes;
    public GameObject deadMenuUI;
    public GameObject pauseMenuUI;
    private void Start()
    {
        Instantiate(tetrominoes[Random.Range(0, tetrominoes.Length)], transform.position, Quaternion.identity);
        _nextTetrominoes = tetrominoes[Random.Range(0, tetrominoes.Length)];
        nextField.sprite = _nextTetrominoes.sprite;
    }

    public void GoAgain()
    {
        Instantiate(_nextTetrominoes, transform.position, Quaternion.identity);
        _nextTetrominoes = tetrominoes[Random.Range(0, tetrominoes.Length)];
        nextField.sprite = _nextTetrominoes.sprite;

        if (deadMenuUI.gameObject.activeSelf)
            nextField.sprite = spriteBlack;
    }

}