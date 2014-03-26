/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.common.dto.order;

import java.math.BigDecimal;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import org.yy.studyapp.core.xml.JaxbHelper;
import static org.junit.Assert.*;

/**
 *
 * @author yyi
 */
public class OrderDtoToXmlTest {

    public OrderDtoToXmlTest() {
    }

    @Test
    public void test1() {
        OrderDto orderDto = new OrderDto();
        orderDto.setAccountId("01-222222-22");
        orderDto.setInstrumentCode("LLS");
        orderDto.setLot(new BigDecimal("10.00"));
        
        JaxbHelper helper = new JaxbHelper("org.yy.studyapp.common.dto.order");
        String xml = helper.toXmlString(orderDto);
        System.out.println(xml);
        OrderDto another = (OrderDto) helper.fromXmlString(xml);
        System.out.println(another.toString());
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    @Before
    public void setUp() {
    }

    @After
    public void tearDown() {
    }
    // TODO add test methods here.
    // The methods must be annotated with annotation @Test. For example:
    //
    // @Test
    // public void hello() {}
}
