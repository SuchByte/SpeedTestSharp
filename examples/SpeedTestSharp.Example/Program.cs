﻿using SpeedTestSharp.Client;
using SpeedTestSharp.Enums;

Console.WriteLine("SpeedTestSharp example");

ISpeedTestClient speedTestClient = new SpeedTestClient();

speedTestClient.StageChanged += (_, stage) =>
{
    Console.WriteLine($"Changed stage to: {stage}");
};

speedTestClient.ProgressChanged += (_, info) =>
{
    switch (speedTestClient.CurrentStage)
    {
        case TestStage.Download:
            Console.Write("Downloaded ");
            break;
        case TestStage.Upload:
            Console.Write("Uploaded ");
            break;
    }
    Console.WriteLine($"{info.BytesProcessed} bytes @ {info.Speed} {speedTestClient.SpeedUnit}");
};

var result = await speedTestClient.TestSpeedAsync(SpeedUnit.Mbps);

Console.WriteLine("============[Finished]============");
Console.WriteLine($"Latency: {result.Latency}ms");
Console.WriteLine($"Download: {result.DownloadSpeed} {result.SpeedUnit}");
Console.WriteLine($"Upload: {result.UploadSpeed} {result.SpeedUnit}");
Console.ReadKey();