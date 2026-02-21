using src.Commands;
using src.Invokers;

namespace src.Models;

public class EditorApplicationV2
{
    private TextEditorV2 _editor;
    private CommandHistory _history = new();

    public EditorApplicationV2()
    {
        _editor = new TextEditorV2();
    }

    public void TypeText(string text)
    {
        var command = new InsertTextCommand(_editor, text);
        _history.Execute(command);
    }

    public void DeleteCharacters(int count)
    {
        var command = new DeleteTextCommand(_editor, count);
        _history.Execute(command);
    }

    public void MakeBold(int start, int length)
    {
        var command = new SetBoldCommand(_editor, start, length);
        _history.Execute(command);
    }

    public void Undo()
    {
        _history.Undo();
    }

    public void Redo()
    {
        _history.Redo();
    }

    public void ShowContent()
    {
        Console.WriteLine($"\n=== Conteúdo do Editor ===");
        Console.WriteLine($"'{_editor.GetContent()}'");
        Console.WriteLine($"Cursor na posição: {_editor.GetCursorPosition()}\n");
    }
}
