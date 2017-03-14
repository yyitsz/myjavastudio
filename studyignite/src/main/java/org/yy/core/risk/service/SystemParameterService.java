package org.yy.core.risk.service;

import javax.cache.annotation.CacheKey;
import javax.cache.annotation.CacheRemove;
import javax.cache.annotation.CacheResult;

/**
 * Created by chinanet on 2017/3/15.
 */
public interface SystemParameterService {
    @CacheResult(cacheName = "systemParameter")
    String getIp(@CacheKey String hostname);

    @CacheRemove(cacheName = "systemParameter" )
    void setIp(@CacheKey String hostname, String ip);
}
