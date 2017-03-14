package org.yy.core.risk.task;

import org.apache.ignite.lang.IgniteCallable;
import org.apache.ignite.resources.SpringResource;
import org.yy.core.risk.service.RiskServer;

/**
 * Created by yyi on 2017/3/14.
 */
public class CalcTask implements IgniteCallable<Long> {

    @SpringResource(resourceClass = RiskServer.class)
    private transient RiskServer riskServer;

    private long v1;
    private long v2;

    public CalcTask(long v1, long v2) {
        this.v1 = v1;
        this.v2 = v2;
    }

    @Override
    public Long call() {
        return riskServer.calc(v1, v2);
    }
}
