using src.Models;

Console.WriteLine("=== Editor de Texto - Problema de Undo/Redo ===\n");

var app = new EditorApplicationV2();

Console.WriteLine("=== Operações ===");
app.TypeText("Hello");
app.TypeText(" World");
app.ShowContent();

app.DeleteCharacters(6); // Deletar " World"
app.ShowContent();

app.MakeBold(0, 5); // Negrito em "Hello"

Console.WriteLine("\n=== Tentando Desfazer ===");
app.Undo(); // Removendo Negrito
app.Redo(); // Reaplicando Negrito

Console.WriteLine("\n=== Adicionando ' World' ===");
app.TypeText(" World"); // adicionando " World" novamente
app.ShowContent();

Console.WriteLine("\n=== Tentando Desfazer ===");
app.Undo(); // removendo " World" novamente
app.ShowContent();

Console.WriteLine("\n=== Tentando Refazer ===");
app.Redo(); // Reaplicando " World" novamente
app.ShowContent();