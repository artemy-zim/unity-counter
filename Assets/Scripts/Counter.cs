using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField, Range(0, float.MaxValue)] private float _counterDelay;

    private Coroutine _counterCoroutine;
    private int _counter = 0;

    private void Update()
    {
        _counterText.text = _counter.ToString();
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_counterCoroutine != null)
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
            else
            {
                _counterCoroutine = StartCoroutine(OnCounterCoroutine());
            }
        }
    }

    private IEnumerator OnCounterCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_counterDelay);

        while (enabled)
        {
            _counter++;

            yield return wait;
        }
    }
}
