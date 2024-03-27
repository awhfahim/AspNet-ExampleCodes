// See https://aka.ms/new-console-template for more information
using FunWithDelegate;
using System.Collections;

var downloader = new Downloader(100);
downloader.DownloadCompleted += (object arg1, int arg2, int arg3) =>
{
    Console.WriteLine($"Download Progress {arg2} bytes out of {arg3}");
};

downloader.DownloadCompleted += (object arg1, int arg2, int arg3) =>
{
    Console.WriteLine($"Progress {arg2} bytes out of {arg3}");
};

downloader.Download();

Console.WriteLine("Download Completed");