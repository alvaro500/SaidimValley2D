using System.Diagnostics.CodeAnalysis;

//To avoid sending unnecessary warnings for common Unity functions (such as Start, Update, Awake, etc.)
[assembly: SuppressMessage("Blocker code smell", "IDE0051",  MessageId = "isChecked")] 

//To not send warnings about converting variables to read-only
[assembly: SuppressMessage("Blocker code smell", "IDE0044",  MessageId = "isChecked")]