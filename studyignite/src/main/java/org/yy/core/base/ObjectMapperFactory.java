package org.yy.core.base;

import com.fasterxml.jackson.core.FormatFeature;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;
import org.springframework.beans.factory.config.AbstractFactoryBean;

/**
 * Created by yyi on 2017/3/16.
 */
public class ObjectMapperFactory extends AbstractFactoryBean<ObjectMapper> {


    @Override
    public Class<?> getObjectType() {
        return ObjectMapper.class;
    }

    @Override
    protected ObjectMapper createInstance() throws Exception {
        ObjectMapper objectMapper = new ObjectMapper();
        //objectMapper.registerModule(new JavaTimeModule());
       // objectMapper.findAndRegisterModules();
     //   objectMapper.registerModule(new JavaTimeModule());
        objectMapper.configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false);
       // objectMapper.configure(FormatFeature)
        return objectMapper;
    }
}
