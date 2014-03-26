/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.main.route;

import org.apache.camel.spring.SpringRouteBuilder;

/**
 *
 * @author yyi
 */
public class StudyAppRoute extends SpringRouteBuilder {

    @Override
    public void configure() throws Exception {
        from("activemq:queue:studyapp.addorder").processRef("addOrderProcessor");
    }
    
}
