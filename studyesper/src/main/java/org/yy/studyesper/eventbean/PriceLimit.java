package org.yy.studyesper.eventbean;

public class PriceLimit
{
    String userId;
    String stockSymbol;
    double limitPct;

    public PriceLimit(String userId, String stockSymbol, double limitPct)
    {
        this.userId = userId;
        this.stockSymbol = stockSymbol;
        this.limitPct = limitPct;
    }

    public String getUserId()
    {
        return userId;
    }

    public String getStockSymbol()
    {
        return stockSymbol;
    }

    public double getLimitPct()
    {
        return limitPct;
    }

    @Override
	public String toString() {
		return "PriceLimit [userId=" + userId + ", stockSymbol=" + stockSymbol
				+ ", limitPct=" + limitPct + "]";
	}
    
}
