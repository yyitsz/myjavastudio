package org.yy.core.risk.service.impl;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

/**
 * Created by yyi on 2017/3/14.
 */
@Service
public class RiskServerImpl implements org.yy.core.risk.service.RiskServer {
    private static Logger logger = LoggerFactory.getLogger(RiskServerImpl.class);

    @Override
    public long calc(long v1, long v2) {
        logger.info("Calculate: {} + {}", v1, v2);
        return v1 + v2;
    }
}
