using System.IO;
using TMPro;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _panel;
    [SerializeField]
    private Animator[] _animators;
    [SerializeField]
    private TextMeshProUGUI _TMPro;

    private bool isShowing = true;

    private int GetLines()
    {
        _TMPro.ForceMeshUpdate();
        var lines = _TMPro.textInfo.lineCount;
        Debug.Log(lines);


        if (lines < 1 || lines > 4)
        {
            lines = 4;
        }
        return lines;
    }

    public void UpdateLinePositions()
    {
        if (isShowing)
        {
            var lines = GetLines();
            foreach (var animator in _animators)
            {
                animator.Play($"{lines}-line");
            }
        }
    }

    public void Hide()
    {
        isShowing = false;
        _panel.Play("Hide");
    }

    public void Pop()
    {
        isShowing=true;
        _panel.Play("Pop");

        var lines = GetLines();

        foreach (var animator in _animators)
        {
            animator.Play($"{lines}-line pop");
        }
    }

    private void Update()
    {
        using (var stream = new FileStream(NewTest.GetParent() + "animation.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            using (var reader = new StreamReader(stream))
            {
                var text = reader.ReadLine();

                if (text == "pop")
                {
                    Pop();
                }
                else if (text == "hide")
                {
                    Hide();
                }
                
            }
        }

        using (var stream = new FileStream(NewTest.GetParent() + "animation.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("");
            }
        }
    }
}
