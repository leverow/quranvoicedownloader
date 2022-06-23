using System.Net;
using System.Diagnostics;

public class AlQuran
{
    private string _curPath = Directory.GetCurrentDirectory();
    private int _countDo = 0;
    public delegate void OnDownloadedDelegate(int orderid, Stopwatch x);
    public OnDownloadedDelegate OnDownloaded {get;set;}
    
    private void run(int number, int downloadFileID)
    {
        var timer = new Stopwatch();
        timer.Start();
        using (var client = new WebClient())
        {
            client.DownloadFile($"https://ia803406.us.archive.org/27/items/AlQuranWithEnglishSaheehIntlTranslation--RecitationByMishariIbnRashidAl-AfasyWithIbrahimWalk/{number:D3}.mp3", $"{_curPath}/downloads/{number:D3}.mp3");
            OnDownloaded?.Invoke(downloadFileID,timer);
        }
    }

    public async void Download(int number)
    {
        if(1 <= number && number <= 114)
        {
            _countDo++;
            Console.WriteLine($"#{_countDo}: Download started");
            
            await Task.Run(() => run(number,_countDo));        
        }
        else
        {
            ColorPrint("ERROR !!! : The surah you entered does not exist in our base!",_Colors.Red);
        }
    }

    public enum _Colors
    {
        Red,
        Green,
        White
    }
    public void ColorPrint(string text,_Colors color)
    {
        var rang = color switch
        {
            _Colors.Red => Console.ForegroundColor = ConsoleColor.Red,
            _Colors.Green => Console.ForegroundColor = ConsoleColor.Green
        };
        Console.WriteLine($"{text}",Console.ForegroundColor);
        Console.ForegroundColor = ConsoleColor.White;
    }
}