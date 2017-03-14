package org.yy.core.risk.service.impl;

import javax.cache.annotation.CacheKeyGenerator;
import javax.cache.annotation.CacheKeyInvocationContext;
import javax.cache.annotation.GeneratedCacheKey;
import java.lang.annotation.Annotation;
import java.util.Objects;

/**
 * Created by chinanet on 2017/3/15.
 */
public class FirstParamCacheKeyGenerator implements CacheKeyGenerator {
    @Override
    public GeneratedCacheKey generateCacheKey(CacheKeyInvocationContext<? extends Annotation> cacheKeyInvocationContext) {
        String key = cacheKeyInvocationContext.getAllParameters()[0].toString();
        return new StringGeneratedCacheKey(key);
    }

    private static class StringGeneratedCacheKey implements GeneratedCacheKey {
        private final String key;

        public StringGeneratedCacheKey(String key) {
            this.key = key;
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (!(o instanceof StringGeneratedCacheKey)) return false;
            StringGeneratedCacheKey that = (StringGeneratedCacheKey) o;
            return Objects.equals(key, that.key);
        }

        @Override
        public int hashCode() {
            return key.hashCode();
        }
    }
}
