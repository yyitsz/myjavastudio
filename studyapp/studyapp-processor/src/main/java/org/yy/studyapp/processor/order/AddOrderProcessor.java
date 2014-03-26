package org.yy.studyapp.processor.order;


import org.apache.camel.Exchange;
import org.apache.camel.Processor;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;


@Service("addOrderProcessor")
@Scope("prototype")
public class AddOrderProcessor implements Processor
{

    @Override
    public void process(Exchange exchange) throws Exception {
       System.out.println(exchange.getIn().getBody());
    }
   
}
