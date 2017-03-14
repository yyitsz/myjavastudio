package org.yy.core.risk.service.impl;

import org.joda.time.LocalDate;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.stereotype.Service;

import javax.cache.annotation.CacheKey;
import javax.cache.annotation.CachePut;
import javax.cache.annotation.CacheRemove;
import javax.cache.annotation.CacheResult;


/**
 * Created by chinanet on 2017/3/14.
 */
@Service
public class SystemParameterServiceImpl implements org.yy.core.risk.service.SystemParameterService {
    private static Logger logger = LoggerFactory.getLogger(SystemParameterServiceImpl.class);

    @Override
    @CacheResult(cacheName = "systemParameter")
    public String getIp(@CacheKey String hostname) {

        LocalDate now = LocalDate.now();

        String ip = hostname + ", " + now;
        logger.info("Get Param: {}, {}", hostname, ip);
        return ip;
    }

    @Override
    @CacheRemove(cacheName = "systemParameter" )
    public void setIp(@CacheKey String hostname, String ip) {
        logger.info("Update Param: {}, {}", hostname, ip);
    }
}
