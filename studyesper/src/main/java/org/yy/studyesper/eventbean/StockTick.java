package org.yy.studyesper.eventbean;

public class StockTick
{
    private String stockSymbol;
    private double price;

    public StockTick(String stockSymbol, double price)
    {
        this.stockSymbol = stockSymbol;
        this.price = price;
    }

    public String getStockSymbol()
    {
        return stockSymbol;
    }

    public double getPrice()
    {
        return price;
    }

    @Override
	public String toString() {
		return "StockTick [stockSymbol=" + stockSymbol + ", price=" + price
				+ "]";
	}
    
    
}
