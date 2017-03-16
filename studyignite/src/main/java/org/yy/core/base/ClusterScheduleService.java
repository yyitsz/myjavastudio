package org.yy.core.base;

import org.apache.ignite.IgniteSpringBean;
import org.apache.ignite.resources.SpringResource;
import org.apache.ignite.services.Service;
import org.apache.ignite.services.ServiceContext;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * Created by chinanet on 2017/3/16.
 */
public class ClusterScheduleService implements Service {
    private static Logger logger = LoggerFactory.getLogger(ClusterScheduleService.class);
  /*  @SpringResource(resourceClass = IgniteSpringBean.class)
    private transient IgniteSpringBean igniteSpringBean;*/

    @Override
    public void cancel(ServiceContext ctx) {
        logger.info(ctx.cacheName() +  ", ClusterScheduleService is cancelled.");
    }

    @Override
    public void init(ServiceContext ctx) throws Exception {
        logger.info(ctx.cacheName()  + ", ClusterScheduleService is init......");
    }

    @Override
    public void execute(ServiceContext ctx) throws Exception {
        logger.info(ctx.cacheName() + ", ClusterScheduleService is executing......");
    }
}
