using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithDelegate;

public class Downloader
{
    public event Action<object, int, int> DownloadCompleted;
    public int totalBytes = 0;
    public int downloadedBytes = 0;

    public Downloader(int totalBytes)
    {
        this.totalBytes = totalBytes;
    }
    public void Download()
    {
        for (int i = 0; i < totalBytes; i++)
        {
            downloadedBytes++;
            if (DownloadCompleted != null)
            {
                DownloadCompleted(this, totalBytes, downloadedBytes);
            }
        }
    }
}


