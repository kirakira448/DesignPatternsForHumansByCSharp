namespace Behavioral
{
    public class Memento
    {
        class EditorMemento
        {
            private string content;
            public EditorMemento(string content)
            {
                this.content = content;
            }

            public string GetContent()  
            {
                return content;
            }
        }

        class Editor
        {
            private string content="";

            public void Type(string words)
            {
                content += words;
            }

            public string GetContent()
            {
                return content;
            }

            public EditorMemento Save()
            {
                return new EditorMemento(content);
            }
            
            public void Restore(EditorMemento memento)
            {
                content = memento.GetContent();
            }
            
        }

        public static void DemonstrateMemento()
        {
            Editor editor = new Editor();
            editor.Type("This is the first sentence.");
            editor.Type("This is the second sentence.");
            editor.Type("This is the third sentence.");
            // Save the current state
            EditorMemento memento = editor.Save();
            // Make some changes
            editor.Type("This is the fourth sentence.");
            Console.WriteLine(editor.GetContent());
            Console.WriteLine("Undoing...");
            // Restore the previous state
            editor.Restore(memento);
            Console.WriteLine(editor.GetContent());
        }
        
    }
}
