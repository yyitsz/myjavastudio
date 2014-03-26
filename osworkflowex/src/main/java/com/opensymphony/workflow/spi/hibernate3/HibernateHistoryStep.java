package com.opensymphony.workflow.spi.hibernate3;



/**
 ?* This is here to persist the historical steps to the historical table.
 *  It is more used more for querying than persistence.
 */
public class HibernateHistoryStep extends HibernateStep {
    //~ Constructors ///////////////////////////////////////////////////////////

    public HibernateHistoryStep() {
    }

    public HibernateHistoryStep(HibernateStep step) {
        super(step);
    }
}
