package org.yy.core.risk.task;

import org.apache.ignite.lang.IgniteCallable;
import org.apache.ignite.resources.SpringResource;
import org.yy.core.risk.service.RiskServer;

/**
 * Created by chinanet on 2017/3/14.
 */
public abstract class IgniteCallableWrapper<P, R> implements IgniteCallable<R> {
    @SpringResource(resourceClass = RiskServer.class)
    private transient RiskServer riskServer;
    private final P param;

    public IgniteCallableWrapper(P param) {
        this.param = param;
    }

    public RiskServer getRiskServer() {
        return riskServer;
    }

    public P getParam() {
        return param;
    }
}
