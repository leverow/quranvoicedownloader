using System.Diagnostics;

var obj = new AlQuran();
obj.OnDownloaded += HandleDownloaded;

void HandleDownloaded(int ID,Stopwatch x)
{
    obj.ColorPrint($"  #{ID}- Download file has been finished in ({x.ElapsedMilliseconds / 1000}sec or {x.ElapsedMilliseconds}ms).",AlQuran._Colors.Green);    
}
while (true)
{
    var x = int.Parse(Console.ReadLine());
    obj.Download(x);
}