using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using IronRuby;
using IronRuby.Runtime;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Providers;

namespace DynamicWP7
{
    public partial class RubyPage
    {
        private readonly ScriptEngine _engine;

        public RubyPage()
        {
            InitializeComponent();

            _engine = Ruby.CreateEngine(setup => setup.Options["CompilationThreshold"] = Int32.MaxValue);
            _engine.Runtime.LoadAssembly(typeof(Color).Assembly);

            var context = (RubyContext)HostingHelpers.GetLanguageContext(_engine);
            context.ObjectClass.SetConstant("Phone", this);

            Assembly execAssembly = Assembly.GetExecutingAssembly();
            Stream codeFile = execAssembly.GetManifestResourceStream("DynamicWP7.RubyPage.rb");
            string code = new StreamReader(codeFile).ReadToEnd();

            _engine.Execute(code);
        }
    }
}