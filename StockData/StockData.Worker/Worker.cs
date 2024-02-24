using HtmlAgilityPack;
using StockData.Application.DTOs;
using StockData.Application.Features;

namespace StockData.Worker;
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IScrapDataManagementService _scrapDataManagementService;

    public Worker(ILogger<Worker> logger, IScrapDataManagementService scrapDataManagementService)
    {
        _logger = logger;
        _scrapDataManagementService = scrapDataManagementService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var html = await new HttpClient().GetStringAsync("https://www.dse.com.bd/latest_share_price_scroll_l.php");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var table = doc.DocumentNode.SelectSingleNode("//table[@class='table table-bordered background-white shares-table fixedHeader']");
            var rows = table.SelectNodes(".//tr");

            foreach (var row in rows)
            {
                var cells = row.SelectNodes(".//td");

                if (cells == null)
                {
                    continue;
                }
                
                CompanyDto companyDto = new()
                {
                    TradeCode = cells[1].InnerText.Trim()
                };

                StockPriceDto stockPriceDto = new()
                {
                    TradeCode = cells[1].InnerText.Trim(),
                    LastTradingPrice = cells[2].InnerText,
                    High = cells[3].InnerText,
                    Low = cells[4].InnerText,
                    ClosePrice = cells[5].InnerText,
                    YesterdayClosePrice = cells[6].InnerText,
                    Change = cells[7].InnerText,
                    Trade = cells[8].InnerText,
                    Value = cells[9].InnerText,
                    Volume = cells[10].InnerText
                };

                await _scrapDataManagementService.InsertCompanyAsync(companyDto);
                await _scrapDataManagementService.InsertStockPriceAsync(stockPriceDto);

                //_logger.LogInformation($"{Id} {symbol} {ltp} {high} {low} {closep} {ycp} {change} {trade} {value} {volume}");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}

