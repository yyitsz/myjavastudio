/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyspring3;

import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.ComponentScan.Filter;
import org.springframework.context.annotation.Configuration;

/**
 *
 * @author yyi
 */
@Configuration
//@ImportResource({"classpath*:rest_config.xml"})
@ComponentScan(basePackages = {"org.yy.studyspring3.bookstore.service"},
        excludeFilters = {@Filter(Configuration.class)})
//@PropertySource({ "persistence.properties", "restfull.properties" }) 

public class AppConfig {
//    @Bean
//    public PropertyPlaceholderConfigurer properties(){
//        PropertyPlaceholderConfigurer ppc = new PreferencesPlaceholderConfigurer();
//        ppc.setLocations(new ClassPathResource[]{
//            new ClassPathResource("pesistence.properties"),
//            new ClassPathResource("restfull.properties")
//        });
//        ppc.setIgnoreUnresolvablePlaceholders(true);
//        return ppc;
//    }
    
}
