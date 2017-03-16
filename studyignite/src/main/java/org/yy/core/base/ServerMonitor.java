package org.yy.core.base;

import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCluster;
import org.apache.ignite.IgniteException;
import org.apache.ignite.IgniteSpringBean;
import org.apache.ignite.lifecycle.LifecycleBean;
import org.apache.ignite.lifecycle.LifecycleEventType;
import org.apache.ignite.resources.SpringResource;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * Created by chinanet on 2017/3/16.
 */
public class ServerMonitor implements LifecycleBean {
    private static Logger logger = LoggerFactory.getLogger(ServerMonitor.class);
//    @SpringResource(resourceClass = IgniteSpringBean.class)
//    private transient IgniteSpringBean igniteSpringBean;

    @Override
    public void onLifecycleEvent(LifecycleEventType evt) throws IgniteException {
        logger.info("Server:" + evt.toString());
    }

}
