package org.yy.studyesper.eventbean;

public class LimitAlert
{
    private StockTick tick;
    private PriceLimit limit;
    double initialPrice;

    public LimitAlert(StockTick tick, PriceLimit limit, double initialPrice)
    {
        this.tick = tick;
        this.limit = limit;
        this.initialPrice = initialPrice;
    }

    public StockTick getTick()
    {
        return tick;
    }

    public PriceLimit getLimit()
    {
        return limit;
    }

    public double getInitialPrice()
    {
        return initialPrice;
    }

	@Override
	public String toString() {
		return "LimitAlert [tick=" + tick + ", limit=" + limit
				+ ", initialPrice=" + initialPrice + "]";
	}

    

}
