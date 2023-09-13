using System;
using System.Threading;

public class TimerService
{
    private Timer timer;
    private VocabManager vocabManager;

    public TimerService(VocabManager manager)
    {
        vocabManager = manager;
        timer = new Timer(TimerCallback, null, 0, 10000); // 30,000 milliseconds (10 seconds)
    }

    private void TimerCallback(object state)
{
    Vocab randomVocab = vocabManager.GetRandomVocab();

    if (randomVocab != null)
    {
        var toast = new ToastContentBuilder()
            .AddArgument("conversationId", 9813)
            .AddText(randomVocab.Term)
            .AddText(randomVocab.Definition);
        toast.Show();
    }
    else
    {
        var toast = new ToastContentBuilder()
            .AddArgument("conversationId", 9813)
            .AddText("No vocabulary words available.");
        toast.Show();
    }
}
}
 