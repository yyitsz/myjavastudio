package org.yy.studyesper.eventbean;

public class DeleteStockTick {
	private String stockSymbol;

	public DeleteStockTick(String stockSymbol) {
		this.stockSymbol = stockSymbol;
	}

	public String getStockSymbol() {
		return stockSymbol;
	}

	public void setStockSymbol(String stockSymbol) {
		this.stockSymbol = stockSymbol;
	}
	
	
}
