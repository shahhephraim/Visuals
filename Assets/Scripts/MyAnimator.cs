using System.IO;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _panel;
    [SerializeField]
    private Animator[] _animators;

    public void Hide()
    {
        _panel.Play("Hide");
    }

    public void Pop(int lines)
    {
        _panel.Play("Pop");

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
                    Pop(4);
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
