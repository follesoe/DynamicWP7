# Include namespaces for ease of use
include System::Windows::Media
include System::Windows::Controls

# Set the titles
Phone.find_name("ApplicationTitle").text = "MSDN Magazine"
Phone.find_name("PageTitle").text = "IronRuby& WP7"

# Create a new text block
textBlock = TextBlock.new
textBlock.text = "IronRuby is running on Windows Phone 7!"
textBlock.foreground = SolidColorBrush.new(Colors.Green)
textBlock.font_size = 48
textBlock.text_wrapping = System::Windows::TextWrapping.Wrap

# Add the text block to the page
Phone.find_name("ContentPanel").children.add(textBlock)