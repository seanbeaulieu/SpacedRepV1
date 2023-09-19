 using Microsoft.Toolkit.Uwp.Notifications;
 
 // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater

public class ToastCreator
{
    private ToastContentBuilder toast;

    public ToastCreator()
    {
        this.toast = new ToastContentBuilder();
    }

    public ToastCreator AddArgument(string key, string value)
    {
        this.toast.AddArgument(key, value);
        return this;
    }

    public ToastCreator PopulateNotification(string term, string definition)
    {
        this.toast.AddText(term);
        this.toast.AddText(definition);
        return this;
    }
}
