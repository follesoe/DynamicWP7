using System.IO;
using System.Reflection;
using System.Windows.Media;

using IronRuby;
using Microsoft.Phone.Controls;
using Microsoft.Scripting.Hosting;

namespace DynamicWP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //ScriptEngine engine = Ruby.CreateEngine();
            //engine.Runtime.LoadAssembly(typeof(Color).Assembly);
            //engine.Runtime.Globals.SetVariable("Phone", this);

            //Assembly execAssembly = Assembly.GetExecutingAssembly();
            //Stream codeFile = execAssembly.GetManifestResourceStream("DynamicWP7.MainPage.rb");
            //string code = new StreamReader(codeFile).ReadToEnd();
            
            //engine.Execute(code);
        }
    }
}