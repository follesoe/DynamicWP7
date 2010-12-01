using System;
using System.IO;
using System.Text;
using System.Windows.Media;

using IronRuby;
using IronRuby.Runtime;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Providers;

namespace DynamicWP7
{
    public partial class MainPage
    {
        private readonly ScriptEngine _engine;
        
        public MainPage()
        {
            InitializeComponent();

            _engine = Ruby.CreateEngine(setup => setup.Options["CompilationThreshold"] = Int32.MaxValue);
            _engine.Runtime.LoadAssembly(typeof(Color).Assembly);

            var context = (RubyContext)HostingHelpers.GetLanguageContext(_engine);
            context.ObjectClass.SetConstant("Phone", this);
        }

        private void RunCode(object sender, EventArgs e)
        {
            _output.Text = string.Empty;

            var stream = new MemoryStream();
            _engine.Runtime.IO.SetOutput(stream, Encoding.UTF8);

            try
            {
                try
                {
                    _engine.Execute(_code.Text.Replace("\r", Environment.NewLine));
                }
                finally
                {
                    byte[] bytes = stream.ToArray();
                    _output.Text += Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                _output.Text += ex.Message;
            }
        }

        private void ClearCode(object sender, EventArgs e)
        {
            _code.Text = string.Empty;
            _output.Text = string.Empty;
        }

        private void LoadSnippet(object sender, EventArgs e)
        {
            _code.Text =
                "include System::Windows::Media\r\r" +
                "color = Colors.Red\r\r" +
                "Phone.find_name(\"_output\").background = \r" +
                "    SolidColorBrush.new(color)\r\r" +

                "def fact n\r" +
                " if n <= 1 then 1 else n * fact(n-1) end\r" +
                "end\r\r" +
                "10.times { |i| puts \"#{i} -> #{fact(i)}\" }\r" +
                "";
        }

        private void GoToRubyPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/RubyPage.xaml", UriKind.Relative));
        }
    }
}